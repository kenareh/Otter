using Otter.Business.Definitions.Factories;
using Otter.Business.Dtos;
using Otter.Business.Dtos.Payment;
using Otter.Common.Entities;

namespace Otter.Business.Implementations.Factories
{
    public class PaymentFactory : BaseFactory<Payment, PaymentDto>, IPaymentFactory
    {
    }
}