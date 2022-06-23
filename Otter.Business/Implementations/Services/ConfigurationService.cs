using System;
using System.Linq;
using Otter.Business.Definitions.Services;
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
            var value = _unitOfWork.ConfigurationRepository.Find(p => p.Key == "PremiumRate").FirstOrDefault();
            if (value == null)
            {
                throw new EntityNotFoundException("نرخ حق بیمه موجود نمی باشد");
            }

            var rate = Convert.ToDouble(value);
            return rate;
        }
    }
}