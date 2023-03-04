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
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Asn1.Ocsp;
using Otter.Business.Definitions.Factories;
using Otter.Business.Definitions.Services;
using Otter.Business.Dtos;
using Otter.Business.Dtos.Payment;
using Otter.Common.Entities;
using Otter.Common.Enums;
using Otter.Common.Exceptions;
using Otter.Common.Tools;
using Otter.DataAccess;
using Otter.ExternalService.Dto;
using Otter.ExternalService.Utilities;
using PaymentRequestResultDto = Otter.ExternalService.Dto.PaymentRequestResultDto;

namespace Otter.Business.Implementations.Services
{
    public class PaymentService : IPaymentService
    {
        private IUnitOfWork _unitOfWork;
        private IConfigurationService _configurationService;
        private IConfiguration _configuration;
        private ILogger<PaymentService> _logger;
        private IPaymentFactory _paymentFactory;
        private IHttpClientService _httpClientService;

        public PaymentService(IConfigurationService configurationService, IUnitOfWork unitOfWork, IConfiguration configuration, ILogger<PaymentService> logger, IPaymentFactory paymentFactory, IHttpClientService httpClientService)
        {
            _configurationService = configurationService;
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _logger = logger;
            _paymentFactory = paymentFactory;
            _httpClientService = httpClientService;
        }

        public PaymentDto Get(long id)
        {
            var payment = _unitOfWork.PaymentRepository.Find(p => p.Id == id).Include(p => p.Policy).FirstOrDefault();
            if (payment == null)
            {
                throw new EntityNotFoundException("پرداخت مورد نظر یافت نشد");
            }

            return _paymentFactory.CreateDto(payment);
        }

        public List<PaymentDto> Get()
        {
            var payments = _unitOfWork.PaymentRepository.Find().ToList();

            return _paymentFactory.CreateDto(payments).ToList();
        }

        public List<PaymentDto> GetByPolicyId(long policyId)
        {
            var payments = _unitOfWork.PaymentRepository.Find(p => p.PolicyId == policyId).ToList();

            return _paymentFactory.CreateDto(payments).ToList();
        }

        public async Task<PaymentRequestResultDto> InsertPaymentRequestAsync(Guid policyGuid, string redirectUrl)
        {
            var policy = _unitOfWork.PolicyRepository.Find(p => p.Guid == policyGuid)
                .FirstOrDefault();
            if (policy == null)
            {
                throw new EntityNotFoundException("یافت نشد.");
            }

            if (!policy.IsMobileConfirmed)
            {
                throw new EntityNotFoundException("یافت نشد.");
            }

            if (policy.PolicyState >= PolicyState.Paid)
            {
                throw new BusinessViolatedException("این بیمه نامه قبلا پرداخت شده است");
            }

            if (policy.FinalPremium == 0)
            {
                policy.PolicyState = PolicyState.Paid;

                var paidPayment = new Payment
                {
                    PolicyId = policy.Id,
                    PaymentId = policy.NationalCode,
                    PremiumAmount = policy.FinalPremium,
                    RequestId = "Zero Premium",
                    Token = "Zero Premium",
                    InsertDate = DateTime.Now,
                    Guid = Guid.NewGuid(),
                    VerifyDate = DateTime.Now,
                    PayerCard = "Zero Premium",
                    RetrievalReferenceNumber = "Zero Premium",
                    SystemTraceAuditNumber = "Zero Premium",
                    IsSuccessful = true
                };

                _unitOfWork.PaymentRepository.Add(paidPayment);
                _unitOfWork.Commit();

                var uiRedirectUrl = _configuration.GetValue<string>("UIUrl") + "payment-result?guid=" + paidPayment.Guid;

                var returnValue = new PaymentRequestResultDto()
                {
                    RedirectUrl = uiRedirectUrl
                };
                return returnValue;
            }

            policy.PolicyState = PolicyState.WaitForPayment;

            var conf = _configurationService.GetPaymentConfiguration();

            var request = new PaymentRequestDto
            {
                Amount = policy.FinalPremium,
                TerminalId = conf.TerminalId,
                PaymentNo = policy.NationalCode,
                CallBackRedirectUrl = redirectUrl
            };

            var paymentBaseUrl = _httpClientService.GetPath(ServiceUrl.IPG);
            var paymentRequestResult = await _httpClientService.PostAsync<PaymentRequestResultDto>(paymentBaseUrl + "payments/requests", request);

            var payment = new Payment()
            {
                PolicyId = policy.Id,
                PaymentId = policy.NationalCode,
                PremiumAmount = policy.FinalPremium,
                RequestId = paymentRequestResult.RequestId,
                Token = paymentRequestResult.Token,
                InsertDate = DateTime.Now,
                Guid = paymentRequestResult.Guid,
            };

            _unitOfWork.PaymentRepository.Add(payment);
            _unitOfWork.Commit();

            return paymentRequestResult;
        }

        public PaymentDto Get(Guid guid)
        {
            var payment = _unitOfWork.PaymentRepository.Find(p => p.Guid == guid).FirstOrDefault();
            if (payment == null)
            {
                throw new EntityNotFoundException("پرداخت مورد نظر یافت نشد");
            }

            return _paymentFactory.CreateDto(payment);
        }

        public async Task<string> CallBackAsync(Guid guid)
        {
            var paymentBaseUrl = _httpClientService.GetPath(ServiceUrl.IPG);
            var paymentResult = await _httpClientService.GetAsync<PaymentDto>(paymentBaseUrl + "payments/" + guid);

            var payment = _unitOfWork.PaymentRepository.Find(p => p.Guid == guid).FirstOrDefault();
            if (payment == null)
            {
                throw new EntityNotFoundException("پرداخت مورد نظر یافت نشد");
            }

            payment.VerifyDate = DateTime.Now;
            payment.PayerCard = paymentResult.PayerCard;
            payment.RetrievalReferenceNumber = paymentResult.RetrievalReferenceNumber;
            payment.SystemTraceAuditNumber = paymentResult.SystemTraceAuditNumber;

            if (paymentResult.IsSuccessful.HasValue && paymentResult.IsSuccessful.Value)
            {
                payment.IsSuccessful = true;
                var policy = _unitOfWork.PolicyRepository.Find(p => p.Id == payment.PolicyId).FirstOrDefault();
                policy.PolicyState = PolicyState.Paid;
            }
            else
            {
                payment.IsSuccessful = false;
                payment.ErrorMessage = paymentResult.ErrorMessage;
            }

            _unitOfWork.Commit();

            var uiRedirectUrl = _configuration.GetValue<string>("UIUrl") + "payment-result?guid=" + payment.Guid;

            return uiRedirectUrl;
        }
    }
}