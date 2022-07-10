using Otter.Business.Dtos;
using Otter.Business.Dtos.Payment;

namespace Otter.Business.Definitions.Services
{
    public interface IConfigurationService
    {
        double GetPremiumRate();

        PaymentConfigurationDto GetPaymentConfiguration();
    }
}