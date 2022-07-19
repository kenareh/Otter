using Otter.Business.Definitions.Factories;
using Otter.Business.Dtos;
using Otter.Business.Dtos.Payment;
using Otter.Common.Entities;

namespace Otter.Business.Implementations.Factories
{
    public class PaymentFactory : BaseFactory<Payment, PaymentDto>, IPaymentFactory
    {
        private IPolicyFactory _policyFactory;

        public PaymentFactory(IPolicyFactory policyFactory)
        {
            _policyFactory = policyFactory;
        }

        public override PaymentDto CreateDto(Payment entity)
        {
            var dto = base.CreateDto(entity);

            if (entity.Policy != null)
            {
                dto.Policy = _policyFactory.CreateDto(entity.Policy);
            }
            return dto;
        }
    }
}