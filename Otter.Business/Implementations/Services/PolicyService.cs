using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Otter.Business.Definitions.Factories;
using Otter.Business.Definitions.Services;
using Otter.Business.Dtos;
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

        public PolicyService(IUnitOfWork unitOfWork, IPolicyFactory policyFactory, ISmsService smsService, ILogger<PolicyService> logger)
        {
            _unitOfWork = unitOfWork;
            _policyFactory = policyFactory;
            _smsService = smsService;
            _logger = logger;
        }

        public async Task<Guid> InsertBasicInformation(BasicInformationRequestDto dto)
        {
            var policy = _policyFactory.CreateEntityFromBasicInformation(dto);

            Random rnd = new Random();
            int num = rnd.Next(11111, 99999);
            policy.Otp = num.ToString();
            policy.OtpExpiredTime = DateTime.Now.AddMinutes(5);
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

            return _policyFactory.CreateDto(policy);
        }

        public PolicyDto AddImei(Guid guid, string imei)
        {
            var policy = _unitOfWork.PolicyRepository.Find(p => p.Guid == guid).FirstOrDefault();
            if (policy == null)
            {
                throw new EntityNotFoundException("کد وارد شده معتبر نمی باشد.");
            }

            if (!policy.IsMobileConfirmed)
            {
                throw new EntityNotFoundException("یافت نشد.");
            }

            policy.Imei = imei;
            _unitOfWork.Commit();

            return _policyFactory.CreateDto(policy);
        }
    }
}