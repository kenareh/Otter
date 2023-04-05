using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Otter.Business.Definitions.Factories;
using Otter.Business.Definitions.Services;
using Otter.Business.Dtos;
using Otter.Common.Entities;
using Otter.Common.Enums;
using Otter.Common.Exceptions;
using Otter.Common.Tools;
using Otter.DataAccess;
using Otter.ExternalService;
using Otter.ExternalService.Dto;
using Otter.ExternalService.Sms;
using Otter.ExternalService.Utilities;

namespace Otter.Business.Implementations.Services
{
    public class PolicyService : IPolicyService
    {
        private IConfiguration _configuration;
        private ILogger<PolicyService> _logger;
        private IUnitOfWork _unitOfWork;
        private IPolicyFactory _policyFactory;
        private ISmsService _smsService;
        private IPolicyFileFactory _policyFileFactory;
        private ISpeakerTestNumberService _speakerTestNumberService;
        private IPremiumInquiryService _premiumInquiryService;
        private ILinkShortenerService _linkShortenerService;
        private ICentralInsuranceIdentityInquiry _centralInsuranceIdentityInquiry;

        public PolicyService(IUnitOfWork unitOfWork, IPolicyFactory policyFactory, ISmsService smsService,
            ILogger<PolicyService> logger, IPolicyFileFactory policyFileFactory, ISpeakerTestNumberService speakerTestNumberService,
            IPremiumInquiryService premiumInquiryService, IConfiguration configuration, ILinkShortenerService linkShortenerService, ICentralInsuranceIdentityInquiry centralInsuranceIdentityInquiry)
        {
            _unitOfWork = unitOfWork;
            _policyFactory = policyFactory;
            _smsService = smsService;
            _logger = logger;
            _policyFileFactory = policyFileFactory;
            _speakerTestNumberService = speakerTestNumberService;
            _premiumInquiryService = premiumInquiryService;
            _configuration = configuration;
            _linkShortenerService = linkShortenerService;
            _centralInsuranceIdentityInquiry = centralInsuranceIdentityInquiry;
        }

        public PolicyFullDto GetFull(long id)
        {
            var policy = _unitOfWork.PolicyRepository.Find(p => p.Id == id)
                .Include(p => p.City).ThenInclude(p => p.Province)
                .Include(p => p.Model).ThenInclude(p => p.Brand)
                .Include(p => p.SpeakerTestNumber)
                .Include(p => p.PolicyFiles)
                .FirstOrDefault();
            if (policy == null)
            {
                throw new EntityNotFoundException("یافت نشد.");
            }

            return _policyFactory.CreateFullDto(policy);
        }

        public List<PolicyDto> Get(FilterRequestDto dto)
        {
            var policies = _unitOfWork.PolicyRepository.Find(p => p.InsertDate.Date >= dto.FromDateTime.Date
                                                                && p.InsertDate.Date <= dto.ToDateTime).ToList();
            return _policyFactory.CreateDto(policies).ToList();
        }

        public List<PolicyDto> GetUncompleted()
        {
            var policies = _unitOfWork.PolicyRepository.Find(p => p.PolicyState != PolicyState.Approved).ToList();
            return _policyFactory.CreateDto(policies).ToList();
        }

        public async Task<FailedStateValidationDto> ValidateAsync(long id, FailedStateValidationDto dto)
        {
            var policy = _unitOfWork.PolicyRepository.Find(p => p.Id == id)
                .FirstOrDefault();
            if (policy == null)
            {
                throw new EntityNotFoundException("یافت نشد.");
            }

            if (dto.MicrophoneTestState || dto.CameraFileState ||
                dto.ImeiFileState || dto.PhoneFileBoxState)
            {
                policy.MicrophoneTestState = dto.MicrophoneTestState;
                policy.CameraFileState = dto.CameraFileState;
                policy.ImeiFileState = dto.ImeiFileState;
                policy.PhoneFileBoxState = dto.PhoneFileBoxState;
                policy.Description = dto.Description;
                policy.PolicyState = PolicyState.Rejected;

                var message = $"درخواست بیمه نامه موبایل شما رد شد. از طریق لینک زیر نسبت به تکمیل فرآیند اقدام فرمایید.\n {policy.ShortUrl} \n بیمه تجارت نو";

                try
                {
                    await _smsService.SendAsync(message, new List<string> { policy.Mobile });
                    policy.IsSendTrackingSms = true;
                }
                catch (Exception e)
                {
                    _logger.LogError(e, e.Message);
                    policy.IsSendTrackingSms = false;
                }
            }
            else
            {
                policy.PolicyState = PolicyState.Approved;
            }

            _unitOfWork.Commit();

            return dto;
        }

        public async Task<Guid> InsertBasicInformation(BasicInformationRequestDto dto)
        {
            var policy = _policyFactory.CreateEntityFromBasicInformation(dto);

            var premiumInquiry = _premiumInquiryService.PremiumInquiry(new InquiryRequestDto()
            {
                DiscountCode = dto.DiscountCode,
                Price = dto.Price
            }, true);

            policy.MarketerCode = dto.MarketerCode;
            policy.PremiumRate = premiumInquiry.PremiumRate;
            policy.FinalPremium = premiumInquiry.FinalPremium;
            policy.BasePremium = premiumInquiry.BasePremium;
            policy.Discount = premiumInquiry.Discount;
            var percent = premiumInquiry.FinalPremium / (decimal)premiumInquiry.BasePremium * 100;
            policy.DiscountPercent = 100 - Convert.ToInt32(percent);
            policy.DiscountCode = dto.DiscountCode;
            policy.InsertDate = DateTime.Now;

            Random rnd = new Random();
            int num = rnd.Next(11111, 99999);
            policy.Otp = num.ToString();
            policy.OtpExpiredTime = DateTime.Now.AddMinutes(2);

            policy.SpeakerTestNumberId = _speakerTestNumberService.SelectRandomNumberVoiceId();
            policy.SpeakerTestAttempt = 0;
            policy.SpeakerTestState = false;

            _unitOfWork.PolicyRepository.Add(policy);
            _unitOfWork.Commit();

            var message = "کد تایید: " + policy.Otp + "\n بیمه تجارت نو";
            try
            {
                await _smsService.SendAsync(message, new List<string>() { policy.Mobile });
            }
            catch (Exception e)
            {
                _logger.LogError(e, "کد تایید ارسال نشد " + policy.Mobile + " : " + policy.Otp);
            }

            return policy.Guid;
        }

        public PolicyDto Get(Guid guid)
        {
            var policy = GetValidPolicy(guid);

            return _policyFactory.CreateDto(policy);
        }

        private Policy GetValidPolicy(Guid guid)
        {
            var policy = _unitOfWork.PolicyRepository.Find(p => p.Guid == guid)
                .Include(p => p.City).ThenInclude(p => p.Province)
                .Include(p => p.Model).ThenInclude(p => p.Brand)
                .Include(p => p.SpeakerTestNumber)
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

        public async Task<PolicyDto> MobileConfirmByOtpAsync(Guid guid, string otp)
        {
            var policy = _unitOfWork.PolicyRepository.Find(p => p.Guid == guid && p.Otp == otp).FirstOrDefault();
            if (policy == null)
            {
                throw new EntityNotFoundException("کد وارد شده معتبر نمی باشد.");
            }

            if (policy.OtpExpiredTime < DateTime.Now)
            {
                throw new BusinessViolatedException("کد ارسال شده منقضی شده است");
            }
            var trackingUrl = _configuration.GetValue<string>("UIUrl") + "policy-state?guid=" + guid;
            var shortLink = await _linkShortenerService.ShortLinkAsync(trackingUrl);
            policy.ShortUrl = shortLink;
            var message = $"از طریق لینک زیر میتوانید ادامه مراحل خرید بیمه نامه را دنبال فرمایید.\n {shortLink} \n بیمه تجارت نو";

            try
            {
                await _smsService.SendAsync(message, new List<string> { policy.Mobile });
                policy.IsSendTrackingSms = true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                policy.IsSendTrackingSms = false;
            }

            policy.IsMobileConfirmed = true;
            policy.PolicyState = PolicyState.MobileConfirmed;
            try
            {
                _unitOfWork.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return _policyFactory.CreateDto(policy);
        }

        public async Task ReissueOtpAsync(Guid guid)
        {
            var policy = _unitOfWork.PolicyRepository.Find(p => p.Guid == guid).FirstOrDefault();
            if (policy == null)
            {
                throw new EntityNotFoundException("کد وارد شده معتبر نمی باشد.");
            }

            if (policy.OtpExpiredTime > DateTime.Now)
            {
                throw new BusinessViolatedException("فرصت وارد کردن رمز یکبار مصرف تمام نشده است");
            }

            Random rnd = new Random();
            int num = rnd.Next(11111, 99999);
            policy.Otp = num.ToString();
            policy.OtpExpiredTime = DateTime.Now.AddMinutes(2);

            _unitOfWork.PolicyRepository.Add(policy);
            _unitOfWork.Commit();

            var message = "کد تایید: " + policy.Otp + "\n بیمه تجارت نو";
            try
            {
                await _smsService.SendAsync(message, new List<string>() { policy.Mobile });
            }
            catch (Exception e)
            {
                _logger.LogError(e, "کد تایید ارسال نشد " + policy.Mobile + " : " + policy.Otp);
            }
        }

        public PolicyDto AddImei(Guid guid, string imei)
        {
            var policy = GetValidPolicy(guid);

            policy.Imei = imei;
            _unitOfWork.Commit();

            return _policyFactory.CreateDto(policy);
        }

        public PolicyDto AddImeiFile(Guid guid, string imeiFileBase64)
        {
            var policy = GetValidPolicy(guid);

            var lastImeiFile = _unitOfWork.PolicyFileRepository.Find(p => p.PolicyId == policy.Id && p.PolicyFileType == PolicyFileType.Imei)
                .FirstOrDefault();
            if (lastImeiFile != null)
            {
                _unitOfWork.PolicyFileRepository.Remove(lastImeiFile);
                _unitOfWork.Commit();
            }

            var newFile = new PolicyFile()
            {
                PolicyFileType = PolicyFileType.Imei,
                PolicyId = policy.Id,
                Base64 = imeiFileBase64
            };
            policy.ImeiFileState = true;
            _unitOfWork.PolicyFileRepository.Add(newFile);
            _unitOfWork.Commit();

            return _policyFactory.CreateDto(policy);
        }

        public PolicyFileDto GetImeiFile(Guid guid)
        {
            var policy = GetValidPolicy(guid);

            var lastImeiFile = _unitOfWork.PolicyFileRepository.Find(p => p.PolicyId == policy.Id && p.PolicyFileType == PolicyFileType.Imei)
                .FirstOrDefault();
            if (lastImeiFile == null)
            {
                throw new EntityNotFoundException("فایل یافت نشد.");
            }

            return _policyFileFactory.CreateDto(lastImeiFile);
        }

        public PolicyDto AddBoxImageFile(Guid guid, string imeiFileBase64)
        {
            var policy = GetValidPolicy(guid);

            var lastBoxFile = _unitOfWork.PolicyFileRepository.Find(p => p.PolicyId == policy.Id && p.PolicyFileType == PolicyFileType.PhoneBox)
                .FirstOrDefault();
            if (lastBoxFile != null)
            {
                _unitOfWork.PolicyFileRepository.Remove(lastBoxFile);
                _unitOfWork.Commit();
            }

            var newFile = new PolicyFile()
            {
                PolicyFileType = PolicyFileType.PhoneBox,
                PolicyId = policy.Id,
                Base64 = imeiFileBase64
            };
            policy.PhoneFileBoxState = true;
            _unitOfWork.PolicyFileRepository.Add(newFile);
            _unitOfWork.Commit();

            return _policyFactory.CreateDto(policy);
        }

        public PolicyFileDto GetBoxImageFile(Guid guid)
        {
            var policy = GetValidPolicy(guid);

            var lastBoxFile = _unitOfWork.PolicyFileRepository.Find(p => p.PolicyId == policy.Id && p.PolicyFileType == PolicyFileType.PhoneBox)
                .FirstOrDefault();
            if (lastBoxFile == null)
            {
                throw new EntityNotFoundException("فایل یافت نشد.");
            }

            return _policyFileFactory.CreateDto(lastBoxFile);
        }

        public Guid GetSpeakerTestFileName(Guid policyGuid)
        {
            var policy = GetValidPolicy(policyGuid);

            return policy.SpeakerTestNumber.FileName;
        }

        public bool SpeakerTest(Guid policyGuid, int number)
        {
            var policy = GetValidPolicy(policyGuid);

            policy.SpeakerTestAttempt++;
            if (policy.SpeakerTestNumber.Number == number)
            {
                policy.SpeakerTestState = true;
                _unitOfWork.Commit();
                return true;
            }

            policy.SpeakerTestState = false;
            _unitOfWork.Commit();

            return false;
        }

        public PolicyDto AddMicrophoneTestFile(Guid guid, string microphoneBase64Voice)
        {
            var policy = GetValidPolicy(guid);

            var microphoneVoiceFile = _unitOfWork.PolicyFileRepository.Find(p => p.PolicyId == policy.Id && p.PolicyFileType == PolicyFileType.MicrophoneVoice)
                .FirstOrDefault();
            if (microphoneVoiceFile != null)
            {
                _unitOfWork.PolicyFileRepository.Remove(microphoneVoiceFile);
                _unitOfWork.Commit();
            }

            var newFile = new PolicyFile()
            {
                PolicyFileType = PolicyFileType.MicrophoneVoice,
                PolicyId = policy.Id,
                Base64 = microphoneBase64Voice
            };
            policy.MicrophoneTestState = true;
            _unitOfWork.PolicyFileRepository.Add(newFile);
            _unitOfWork.Commit();

            return _policyFactory.CreateDto(policy);
        }

        public PolicyFileDto GetMicrophoneTestFile(Guid guid)
        {
            var policy = GetValidPolicy(guid);

            var file = _unitOfWork.PolicyFileRepository.Find(p => p.PolicyId == policy.Id && p.PolicyFileType == PolicyFileType.MicrophoneVoice)
                .FirstOrDefault();
            if (file == null)
            {
                throw new EntityNotFoundException("فایل یافت نشد.");
            }

            return _policyFileFactory.CreateDto(file);
        }

        public PolicyDto ScreenTest(Guid guid)
        {
            var policy = GetValidPolicy(guid);

            policy.ScreenTestState = true;

            _unitOfWork.Commit();

            return _policyFactory.CreateDto(policy);
        }

        public PolicyDto AddCameraFiles(Guid guid, string frontCameraBase64Image, string backCameraBase64Image)
        {
            var policy = GetValidPolicy(guid);

            var front = _unitOfWork.PolicyFileRepository.Find(p => p.PolicyId == policy.Id && p.PolicyFileType == PolicyFileType.FrontCamera)
                .FirstOrDefault();
            if (front != null)
            {
                _unitOfWork.PolicyFileRepository.Remove(front);
                _unitOfWork.Commit();
            }
            var newFrontFile = new PolicyFile()
            {
                PolicyFileType = PolicyFileType.FrontCamera,
                PolicyId = policy.Id,
                Base64 = frontCameraBase64Image
            };
            _unitOfWork.PolicyFileRepository.Add(newFrontFile);

            var back = _unitOfWork.PolicyFileRepository.Find(p => p.PolicyId == policy.Id && p.PolicyFileType == PolicyFileType.BackCamera)
                .FirstOrDefault();
            if (back != null)
            {
                _unitOfWork.PolicyFileRepository.Remove(front);
                _unitOfWork.Commit();
            }
            var newBackFile = new PolicyFile()
            {
                PolicyFileType = PolicyFileType.FrontCamera,
                PolicyId = policy.Id,
                Base64 = backCameraBase64Image
            };
            policy.CameraFileState = true;

            _unitOfWork.PolicyFileRepository.Add(newBackFile);

            _unitOfWork.Commit();

            return _policyFactory.CreateDto(policy);
        }

        public List<PolicyFileDto> GetCameraFiles(Guid guid)
        {
            var policy = GetValidPolicy(guid);

            var files = _unitOfWork.PolicyFileRepository.Find(p => p.PolicyId == policy.Id &&
                                                                          (p.PolicyFileType == PolicyFileType.FrontCamera || p.PolicyFileType == PolicyFileType.BackCamera))
                .ToList();

            return _policyFileFactory.CreateDto(files).ToList();
        }

        public async Task<PolicyDto> InsertPersonalInformationAsync(Guid guid, PersonalInfoDto dto)
        {
            var policy = GetValidPolicy(guid);

            policy.Firstname = dto.Firstname;
            policy.Lastname = dto.Lastname;
            policy.NationalCode = dto.NationalCode;
            policy.BirthDate = dto.BirthDate;
            policy.BirthDateString = dto.BirthDate.ToString();
            policy.Address = dto.Address;
            policy.CityId = dto.CityId;

            CentralInsuranceIdentityInquiryResultDto inquiry;

            inquiry = await _centralInsuranceIdentityInquiry.InquiryAsync(dto.NationalCode,
                Convert.ToInt32(dto.BirthDate.GetJalaliYear()));

            policy.FatherName = inquiry.FatherName;
            policy.ShenasnameNo = inquiry.ShenasnameNo;
            policy.Gender = (Gender)inquiry.Gender.Id;
            policy.PostalCode = inquiry.Zipcode;
            _unitOfWork.Commit();

            return _policyFactory.CreateDto(policy);
        }

        public byte[] GetExcelPoliciesForIssue(FilterRequestDto dto, string fileName)
        {
            var policies = _unitOfWork.PolicyRepository.Find(p => p.PolicyState == PolicyState.Approved
                                                                && p.InsertDate.Date >= dto.FromDateTime.Date
                                                                && p.InsertDate.Date <= dto.ToDateTime)
                .Include(p => p.City).ThenInclude(p => p.Province)
                .Include(p => p.Model).ThenInclude(p => p.Brand).ToList();

            var excelData = policies.Select(p => new FannavaranExcelDto()
            {
                PersonKind = 46.ToString(),
                PersonName = p.Firstname,
                PersonLName = p.Lastname,
                IsIranian = 1.ToString(),
                // Nationality =
                CodeMelli = p.NationalCode,
                // UnIranianCode =
                PersonJens = GetFannavaranGender(p.Gender).ToString(),
                BirthYear = p.BirthDate.GetJalaliYear(),
                // GElhNo =
                BirthMonth = p.BirthDate.GetJalaliMonth(),
                BirthDay = p.BirthDate.GetJalaliDay(),
                IdentityNo = p.ShenasnameNo.ToString(),
                SodurPlace = p.City.Name,
                FatherName = p.FatherName,
                // Economic =
                // CompanyCode =
                // SabtNo =
                Tel = "88888888",
                Mobile = p.Mobile,
                // CodePosti = p. todo
                PersonAddress = p.Address,
                PayerPersonKind = "46",
                PayerPersonName = p.Firstname,
                PayerPersonLName = p.Lastname,
                // PayerNationality =
                PayerCodeMelli = p.NationalCode,
                // PayerUnIranianCode =
                PayerPersonJens = GetFannavaranGender(p.Gender).ToString(),

                PayerBirthYear = p.BirthDate.GetJalaliYear(),
                PayerBirthMonth = p.BirthDate.GetJalaliMonth(),
                PayerBirthDay = p.BirthDate.GetJalaliDay(),

                PayerIdentityNo = p.ShenasnameNo.ToString(),
                PayerSodurPlace = p.City.Name,
                PayerFatherName = p.FatherName,
                // PayerEconomic =
                // PayerCompanyCode =
                // PayerSabtNo =

                PayerMobile = p.Mobile,
                PayerTel = "88888888",
                // PayerCodePosti = todo
                PayerPersonAddress = p.Address,
                BeginDate = p.InsertDate.ToJalaliDate(),
                EndDate = p.InsertDate.AddYears(1).ToJalaliDate(),

                // LastBimeCompany =
                // ExtendedBNNo =
                // InternalOldBId =
                // ExtendedBNNo =
                TakhfifPercent = p.DiscountPercent.ToString(),
                // FishNo =
                // FishDate =
                // Bank =
                // BankBranch =
                // BankBranchNumber =
                Name = p.Model.Name,
                Brand = p.Model.Brand.Name,
                SerialNo = p.Imei,

                // ManufactureYear = p. todo

                PartOneSarmaye = p.Price.ToString(),
                NerkhPartOne = p.PremiumRate.ToString(),
                PartOneHB = p.FinalPremium.ToString(),

                // PartTwoSarmaye =
                // FranshizDarsadPartTwo =
                // MinFranshizPartTwo =
                // PartTwoHB =

                FillPayerFromBimegozar = "1"
            })
                .ToList();
            var result = ExportToExcel.ExportToXlsx(excelData, fileName);
            return result;
        }

        private int GetFannavaranGender(Gender gender)
        {
            if (gender == Gender.Man)
            {
                return 26; //man
            }
            else
            {
                return 27; //woman
            }
        }
    }
}