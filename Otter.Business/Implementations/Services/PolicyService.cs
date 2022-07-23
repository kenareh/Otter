using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Otter.Business.Definitions.Factories;
using Otter.Business.Definitions.Services;
using Otter.Business.Dtos;
using Otter.Common.Entities;
using Otter.Common.Enums;
using Otter.Common.Exceptions;
using Otter.Common.Tools;
using Otter.DataAccess;
using Otter.ExternalService.Sms;
using Otter.ExternalService.Utilities;

namespace Otter.Business.Implementations.Services
{
    public class PolicyService : IPolicyService
    {
        private ILogger<PolicyService> _logger;
        private IUnitOfWork _unitOfWork;
        private IPolicyFactory _policyFactory;
        private ISmsService _smsService;
        private IPolicyFileFactory _policyFileFactory;
        private ISpeakerTestNumberService _speakerTestNumberService;
        private IPremiumInquiryService _premiumInquiryService;
        private IAgentService _agentService;

        public PolicyService(IUnitOfWork unitOfWork, IPolicyFactory policyFactory, ISmsService smsService,
            ILogger<PolicyService> logger, IPolicyFileFactory policyFileFactory, ISpeakerTestNumberService speakerTestNumberService, IPremiumInquiryService premiumInquiryService, IAgentService agentService)
        {
            _unitOfWork = unitOfWork;
            _policyFactory = policyFactory;
            _smsService = smsService;
            _logger = logger;
            _policyFileFactory = policyFileFactory;
            _speakerTestNumberService = speakerTestNumberService;
            _premiumInquiryService = premiumInquiryService;
            _agentService = agentService;
        }

        public PolicyFullDto GetFull(long id)
        {
            var policy = _unitOfWork.PolicyRepository.Find(p => p.Id == id)
                .Include(p => p.City).ThenInclude(p => p.Province)
                .Include(p => p.Model).ThenInclude(p => p.Brand)
                .Include(p => p.SpeakerTestNumber)
                .Include(p => p.PolicyFiles)
                .Include(p => p.Agent)
                .FirstOrDefault();
            if (policy == null)
            {
                throw new EntityNotFoundException("یافت نشد.");
            }

            return _policyFactory.CreateFullDto(policy);
        }

        public List<PolicyDto> Get()
        {
            var policies = _unitOfWork.PolicyRepository.Find().ToList();
            return _policyFactory.CreateDto(policies).ToList();
        }

        public async Task<Guid> InsertBasicInformation(BasicInformationRequestDto dto)
        {
            var policy = _policyFactory.CreateEntityFromBasicInformation(dto);

            var premiumInquiry = _premiumInquiryService.PremiumInquiry(new InquiryRequestDto()
            {
                DiscountCode = dto.DiscountCode,
                Price = dto.Price
            }, true);

            if (!dto.AgentCode.IsNullOrEmpty())
            {
                var agent = _agentService.Get(dto.AgentCode);
                policy.AgentId = agent.Id;
            }

            policy.PremiumRate = premiumInquiry.PremiumRate;
            policy.FinalPremium = premiumInquiry.FinalPremium;
            policy.BasePremium = premiumInquiry.BasePremium;
            policy.Discount = premiumInquiry.Discount;
            policy.DiscountCode = dto.DiscountCode;

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

        public PolicyDto MobileConfirmByOtp(Guid guid, string otp)
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

            policy.IsMobileConfirmed = true;
            policy.PolicyState = PolicyState.MobileConfirmed;
            _unitOfWork.Commit();

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

        public PolicyDto InsertPersonalInformation(Guid guid, PersonalInfoDto dto)
        {
            var policy = GetValidPolicy(guid);

            policy.Firstname = dto.Firstname;
            policy.Lastname = dto.Lastname;
            policy.NationalCode = dto.NationalCode;
            policy.BirthDate = dto.BirthDate;
            policy.BirthDateString = dto.BirthDate.ToString(CultureInfo.InvariantCulture);
            policy.Address = dto.Address;
            policy.CityId = dto.CityId;

            _unitOfWork.Commit();

            return _policyFactory.CreateDto(policy);
        }
    }
}