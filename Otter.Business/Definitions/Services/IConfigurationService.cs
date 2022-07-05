using Otter.Business.Dtos;

namespace Otter.Business.Definitions.Services
{
    public interface IConfigurationService
    {
        double GetPremiumRate();

        PaymentConfigurationDto GetPaymentConfiguration();
    }
}