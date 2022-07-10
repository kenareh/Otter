using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Otter.Business.Definitions.Services;
using Otter.Business.Dtos;
using Otter.Business.Dtos.Payment;
using Otter.Common.Entities;
using Otter.Common.Exceptions;
using Otter.Common.Tools;
using Otter.DataAccess;

namespace Otter.Business.Implementations.Services
{
    public class PaymentService : IPaymentService
    {
        private IUnitOfWork _unitOfWork;
        private IConfigurationService _configurationService;
        private IConfiguration _configuration;
        private ILogger<PaymentService> _logger;

        public PaymentService(IConfigurationService configurationService, IUnitOfWork unitOfWork, IConfiguration configuration, ILogger<PaymentService> logger)
        {
            _configurationService = configurationService;
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<PaymentRequestResultDto> InsertPaymentRequestAsync(Guid policyGuid)
        {
            var policy = GetValidPolicy(policyGuid);

            var requestId = (_unitOfWork.PaymentRepository.Find().Count() + 10000).ToString();

            var redirectUrl = _configuration.GetValue<string>("PaymentRedirectUrl");

            var token = await GetTokenAsync(policy.FinalPremium, requestId, policy.NationalCode, redirectUrl);

            var payment = new Payment()
            {
                PolicyId = policy.Id,
                PaymentId = policy.NationalCode,
                PremiumAmount = policy.FinalPremium,
                RequestId = requestId,
                Token = token,
                InsertDate = DateTime.Now
            };
            _unitOfWork.PaymentRepository.Add(payment);
            _unitOfWork.Commit();

            return new PaymentRequestResultDto()
            {
                Token = token
            };
        }

        private Policy GetValidPolicy(Guid guid)
        {
            var policy = _unitOfWork.PolicyRepository.Find(p => p.Guid == guid)
                .FirstOrDefault();
            if (policy == null)
            {
                throw new EntityNotFoundException("یافت نشد.");
            }

            if (!policy.IsMobileConfirmed)
            {
                throw new EntityNotFoundException("یافت نشد.");
            }

            return policy;
        }

        private async Task<string> GetTokenAsync(long amount, string requestId, string paymentId, string revertUrl)
        {
            var conf = _configurationService.GetPaymentConfiguration();

            RequestClass requestClass = new RequestClass();
            // requestClass.Request.CmsPreservationId = iPGData.CmsPreservationId;
            //requestClass.Request.additionalParameters = new List<KeyValuePair<string, string>>
            //{
            //    new KeyValuePair<string, string>("nationalId","1045879569")
            //};
            requestClass.Request.AcceptorId = conf.AcceptorId;
            requestClass.Request.amount = amount;
            requestClass.Request.BillInfo = null;
            // requestClass.Request.multiplexParameters = null;
            requestClass.Request.PaymentId = paymentId;
            requestClass.Request.RequestId = requestId;
            requestClass.Request.RevertUri = revertUrl;
            requestClass.Request.terminalId = conf.TerminalId;
            requestClass.Request.RequestTimestamp = (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            requestClass.Request.transactionType = "Purchase";

            AESCoding.CreateAESCoding(requestClass, conf.RsaPublicKey, conf.PassPhrase, requestClass.Request.multiplexParameters == null ? false : true);

            var json = JsonConvert.SerializeObject(requestClass);

            var http = new HttpClient()
            {
                BaseAddress = new Uri("https://ikc.shaparak.ir/api/v3/tokenization/make")
            }; ;

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await http.PostAsync("", content);
            var resp = await response.Content.ReadAsStringAsync();
            TokenResultDto result = JsonConvert.DeserializeObject<TokenResultDto>(resp);
            if (result.Status && result.ResponseCode == "00")
            {
                return result.Result.Token;
            }
            else
            {
                throw new BusinessViolatedException(GetError(result.ResponseCode));
            }
        }

        public async Task<VerifyResultDto> VerifyAsync(string token, string responseCode, string acceptorId, string amount, string paymentId,
            string requestId, string retrievalReferenceNumber, string systemTraceAuditNumber, string maskedPan)
        {
            var payment = _unitOfWork.PaymentRepository.Find(p => p.Token == token && p.RequestId == requestId).FirstOrDefault();
            if (payment == null)
            {
                throw new EntityNotFoundException("پرداخت مورد نظر یافت نشد");
            }

            var result = await IranKishVerifyAsync(token, retrievalReferenceNumber, systemTraceAuditNumber);

            payment.VerifyDate = DateTime.Now;
            payment.PayerCard = maskedPan;
            payment.IsSuccessful = true;

            _unitOfWork.Commit();

            return new VerifyResultDto()
            {
                DateTime = DateTime.Now,
                PayerCard = maskedPan,
                RetrievalReferenceNumber = retrievalReferenceNumber,
                SystemTraceAuditNumber = systemTraceAuditNumber
            };
        }

        private async Task<IranKishVerifyResultDataDto> IranKishVerifyAsync(string token, string retrievalReferenceNumber, string systemTraceAuditNumber)
        {
            var conf = _configurationService.GetPaymentConfiguration();

            IranKishVerifyRequestDto requestVerify = new IranKishVerifyRequestDto
            {
                TerminalId = conf.TerminalId,
                SystemTraceAuditNumber = systemTraceAuditNumber,
                RetrievalReferenceNumber = retrievalReferenceNumber,
                TokenIdentity = token
            };

            var http = new HttpClient()
            {
                BaseAddress = new Uri("https://ikc.shaparak.ir/api/v3/confirmation/purchase")
            };

            var json = JsonConvert.SerializeObject(requestVerify);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await http.PostAsync("", content);
            var resp = await response.Content.ReadAsStringAsync();
            IranKishVerifyResultDto result = JsonConvert.DeserializeObject<IranKishVerifyResultDto>(resp);
            if (result.status && result.responseCode == "00")
            {
                return result.result;
            }
            else
            {
                throw new BusinessViolatedException(GetError(result.responseCode));
            }
        }

        private string GetError(string statusCode)
        {
            try
            {
                Dictionary<string, string> errors = new Dictionary<string, string>();

                errors.Add("5", "از انجام تراکنش صرف نظر شد");
                errors.Add("3", "پذیرنده فروشگاهی نا معتبر است");
                errors.Add("64", "مبلغ تراکنش نادرست است،جمع مبالغ تقسیم وجوه برابر مبلغ کل تراکنش نمی باشد");
                errors.Add("94", "تراکنش تکراری است");
                errors.Add("25", "تراکنش اصلی یافت نشد");
                errors.Add("77", "روز مالی تراکنش نا معتبر است");
                errors.Add("97", "کد تولید کد اعتبار سنجی نا معتبر است");
                errors.Add("30", " فرمت پیام نادرست است");
                errors.Add("86", "شتاب در حال Off Sign است");
                errors.Add("55", "رمز کارت نادرست است");
                errors.Add("40", "عمل درخواستی پشتیبانی نمی شود");
                errors.Add("57", "انجام تراکنش مورد درخواست توسط پایانه انجام دهنده مجاز نمی باشد");
                errors.Add("58", "انجام تراکنش مورد درخواست توسط پایانه انجام دهنده مجاز نمی باشد");
                errors.Add("63", "تمهیدات امنیتی نقض گردیده است");
                errors.Add("96", "قوانین سامانه نقض گردیده است ، خطای داخلی سامانه");
                errors.Add("2", "تراکنش قبلا برگشت شده است");
                errors.Add("54", "تاریخ انقضا کارت سررسید شده است");
                errors.Add("62", "کارت محدود شده است");
                errors.Add("75", "تعداد دفعات ورود رمز اشتباه از حد مجاز فراتر رفته است");
                errors.Add("14", "اطلاعات کارت صحیح نمی باشد");
                errors.Add("51", "موجودی حساب کافی نمی باشد");
                errors.Add("56", "اطلاعات کارت یافت نشد");
                errors.Add("61", "مبلغ تراکنش بیش از حد مجاز است");
                errors.Add("65", "تعداد دفعات انجام تراکنش بیش از حد مجاز است");
                errors.Add("78", "کارت فعال نیست");
                errors.Add("79", "حساب متصل به کارت بسته یا دارای اشکال است");
                errors.Add("42", "کارت یا حساب مبدا در وضعیت پذیرش نمی باشد");
                errors.Add("31", "عدم تطابق کد ملی خریدار با دارنده کارت");
                errors.Add("98", "سقف استفاده از رمز دوم ایستا به پایان رسیده است");
                errors.Add("901", "درخواست نا معتبر است )Tokenization)");
                errors.Add("902", "پارامترهای اضافی درخواست نامعتبر می باشد )Tokenization)");
                errors.Add("903", "شناسه پرداخت نامعتبر می باشد )Tokenization)");
                errors.Add("904", "اطالعات مرتبط با قبض نا معتبر می باشد )Tokenization)");
                errors.Add("905", "شناسه درخواست نامعتبر می باشد )Tokenization)");
                errors.Add("906", "درخواست تاریخ گذشته است )Tokenization)");
                errors.Add("907", "آدرس بازگشت نتیجه پرداخت نامعتبر می باشد )Tokenization)");
                errors.Add("909", "پذیرنده نامعتبر می باشد)Tokenization)");
                errors.Add("910", "پارامترهای مورد انتظار پرداخت تسهیمی تامین نگردیده است)Tokenization)");
                errors.Add("911", "پارامترهای مورد انتظار پرداخت تسهیمی نا معتبر یا دارای اشکال می باشد)Tokenization)");
                errors.Add("912", "تراکنش درخواستی برای پذیرنده فعال نیست )Tokenization)");
                errors.Add("913", "تراکنش تسهیم برای پذیرنده فعال نیست )Tokenization)");
                errors.Add("914", "آدرس آی پی دریافتی درخواست نا معتبر می باشد");
                errors.Add("915", "شماره پایانه نامعتبر می باشد )Tokenization)");
                errors.Add("916", "شماره پذیرنده نا معتبر می باشد )Tokenization)");
                errors.Add("917", "نوع تراکنش اعالم شده در خواست نا معتبر می باشد )Tokenization)");
                errors.Add("918", "پذیرنده فعال نیست)Tokenization)");
                errors.Add("919", "مبالغ تسهیمی ارائه شده با توجه به قوانین حاکم بر وضعیت تسهیم پذیرنده ، نا معتبر است )Tokenization)");
                errors.Add("920", "شناسه نشانه نامعتبر می باشد");
                errors.Add("921", "شناسه نشانه نامعتبر و یا منقضی شده است");
                errors.Add("922", "نقض امنیت درخواست )Tokenization)");
                errors.Add("923", "ارسال شناسه پرداخت در تراکنش قبض مجاز نیست)Tokenization)");
                errors.Add("928", "مبلغ مبادله شده نا معتبر می باشد)Tokenization)");
                errors.Add("929", "شناسه پرداخت ارائه شده با توجه به الگوریتم متناظر نا معتبر می باشد)Tokenization)");
                errors.Add("930", "کد ملی ارائه شده نا معتبر می باشد)Tokenization)");

                var error = errors.FirstOrDefault(p => p.Key == statusCode).Value;
                return error;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                throw;
            }
        }
    }
}