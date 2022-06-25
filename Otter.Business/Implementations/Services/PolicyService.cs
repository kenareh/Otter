using System;
using System.Collections.Generic;
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

        public PolicyService(IUnitOfWork unitOfWork, IPolicyFactory policyFactory, ISmsService smsService,
            ILogger<PolicyService> logger, IPolicyFileFactory policyFileFactory, ISpeakerTestNumberService speakerTestNumberService, IPremiumInquiryService premiumInquiryService)
        {
            _unitOfWork = unitOfWork;
            _policyFactory = policyFactory;
            _smsService = smsService;
            _logger = logger;
            _policyFileFactory = policyFileFactory;
            _speakerTestNumberService = speakerTestNumberService;
            _premiumInquiryService = premiumInquiryService;
        }

        public async Task<Guid> InsertBasicInformation(BasicInformationRequestDto dto)
        {
            var policy = _policyFactory.CreateEntityFromBasicInformation(dto);

            var premiumInquiry = _premiumInquiryService.PremiumInquiry(new InquiryRequestDto()
            {
                DiscountCode = dto.DiscountCode,
                Price = dto.Price
            }, true);

            policy.PremiumRate = premiumInquiry.PremiumRate;
            policy.FinalPremium = premiumInquiry.FinalPremium;
            policy.BasePremium = premiumInquiry.BasePremium;
            policy.Discount = premiumInquiry.Discount;
            policy.DiscountCode = dto.DiscountCode;

            Random rnd = new Random();
            int num = rnd.Next(11111, 99999);
            policy.Otp = num.ToString();
            policy.OtpExpiredTime = DateTime.Now.AddMinutes(5);

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
            var policy = _unitOfWork.PolicyRepository.Find(p => p.Guid == guid).FirstOrDefault();
            if (policy == null)
            {
                throw new EntityNotFoundException("یافت نشد.");
            }

            if (!policy.IsMobileConfirmed)
            {
                throw new EntityNotFoundException("یافت نشد.");
            }

            return _policyFactory.CreateDto(policy);
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

        public PolicyDto AddImeiFile(Guid guid, string imeiFileBase64)
        {
            var policy = _unitOfWork.PolicyRepository.Find(p => p.Guid == guid).FirstOrDefault();
            if (policy == null)
            {
                throw new EntityNotFoundException("یافت نشد.");
            }

            if (!policy.IsMobileConfirmed)
            {
                throw new EntityNotFoundException("یافت نشد.");
            }

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
            var policy = _unitOfWork.PolicyRepository.Find(p => p.Guid == guid).FirstOrDefault();
            if (policy == null)
            {
                throw new EntityNotFoundException("یافت نشد.");
            }

            if (!policy.IsMobileConfirmed)
            {
                throw new EntityNotFoundException("یافت نشد.");
            }
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
            var policy = _unitOfWork.PolicyRepository.Find(p => p.Guid == guid).FirstOrDefault();
            if (policy == null)
            {
                throw new EntityNotFoundException("یافت نشد.");
            }

            if (!policy.IsMobileConfirmed)
            {
                throw new EntityNotFoundException("یافت نشد.");
            }

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
            var policy = _unitOfWork.PolicyRepository.Find(p => p.Guid == guid).FirstOrDefault();
            if (policy == null)
            {
                throw new EntityNotFoundException("یافت نشد.");
            }

            if (!policy.IsMobileConfirmed)
            {
                throw new EntityNotFoundException("یافت نشد.");
            }
            var lastBoxFile = _unitOfWork.PolicyFileRepository.Find(p => p.PolicyId == policy.Id && p.PolicyFileType == PolicyFileType.PhoneBox)
                .FirstOrDefault();
            if (lastBoxFile == null)
            {
                throw new EntityNotFoundException("فایل یافت نشد.");
            }

            return _policyFileFactory.CreateDto(lastBoxFile);
        }

        public bool SpeakerTest(Guid policyGuid, int number)
        {
            var policy = _unitOfWork.PolicyRepository.Find(p => p.Guid == policyGuid).Include(p => p.SpeakerTestNumber).FirstOrDefault();
            if (policy == null)
            {
                throw new EntityNotFoundException("یافت نشد.");
            }

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
            var policy = _unitOfWork.PolicyRepository.Find(p => p.Guid == guid).FirstOrDefault();
            if (policy == null)
            {
                throw new EntityNotFoundException("یافت نشد.");
            }

            if (!policy.IsMobileConfirmed)
            {
                throw new EntityNotFoundException("یافت نشد.");
            }

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
            var policy = _unitOfWork.PolicyRepository.Find(p => p.Guid == guid).FirstOrDefault();
            if (policy == null)
            {
                throw new EntityNotFoundException("یافت نشد.");
            }

            if (!policy.IsMobileConfirmed)
            {
                throw new EntityNotFoundException("یافت نشد.");
            }
            var file = _unitOfWork.PolicyFileRepository.Find(p => p.PolicyId == policy.Id && p.PolicyFileType == PolicyFileType.MicrophoneVoice)
                .FirstOrDefault();
            if (file == null)
            {
                throw new EntityNotFoundException("فایل یافت نشد.");
            }

            return _policyFileFactory.CreateDto(file);
        }

        public PolicyDto WhiteDotTest(Guid guid)
        {
            var policy = _unitOfWork.PolicyRepository.Find(p => p.Guid == guid).FirstOrDefault();
            if (policy == null)
            {
                throw new EntityNotFoundException("یافت نشد.");
            }

            if (!policy.IsMobileConfirmed)
            {
                throw new EntityNotFoundException("یافت نشد.");
            }

            policy.WhiteDotTestState = true;

            _unitOfWork.Commit();

            return _policyFactory.CreateDto(policy);
        }

        public PolicyDto DarkDotTest(Guid guid)
        {
            var policy = _unitOfWork.PolicyRepository.Find(p => p.Guid == guid).FirstOrDefault();
            if (policy == null)
            {
                throw new EntityNotFoundException("یافت نشد.");
            }

            if (!policy.IsMobileConfirmed)
            {
                throw new EntityNotFoundException("یافت نشد.");
            }

            policy.DarkDotTestState = true;

            _unitOfWork.Commit();

            return _policyFactory.CreateDto(policy);
        }

        public PolicyDto SquareTouchTest(Guid guid)
        {
            var policy = _unitOfWork.PolicyRepository.Find(p => p.Guid == guid).FirstOrDefault();
            if (policy == null)
            {
                throw new EntityNotFoundException("یافت نشد.");
            }

            if (!policy.IsMobileConfirmed)
            {
                throw new EntityNotFoundException("یافت نشد.");
            }

            policy.SquareTouchTestState = true;

            _unitOfWork.Commit();

            return _policyFactory.CreateDto(policy);
        }
    }
}