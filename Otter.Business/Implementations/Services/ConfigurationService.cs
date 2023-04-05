using System;
using System.Linq;
using Otter.Business.Definitions.Services;
using Otter.Business.Dtos;
using Otter.Business.Dtos.Payment;
using Otter.Common.Exceptions;
using Otter.DataAccess;

namespace Otter.Business.Implementations.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private IUnitOfWork _unitOfWork;

        public ConfigurationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public double GetPremiumRate()
        {
            var configuration = _unitOfWork.ConfigurationRepository.Find(p => p.Key == "PremiumRate").FirstOrDefault();
            if (configuration == null)
            {
                throw new EntityNotFoundException("نرخ حق بیمه موجود نمی باشد");
            }

            var rate = Convert.ToDouble(configuration.Value);
            return rate;
        }

        public PaymentConfigurationDto GetPaymentConfiguration()
        {
            var paymentConfiguration = new PaymentConfigurationDto();

            var terminalId = _unitOfWork.ConfigurationRepository.Find(p => p.Key == "IPGTerminalId").FirstOrDefault();
            if (terminalId == null)
            {
                throw new EntityNotFoundException("شماره ترمینال موجود نمی باشد");
            }
            paymentConfiguration.TerminalId = terminalId.Value;

            return paymentConfiguration;
        }
    }
}