using Otter.Business.Dtos;
using Otter.Business.Dtos.Discount;
using Otter.Business.Dtos.Payment;
using Otter.Common.Entities;

namespace Otter.Business.Definitions.Factories
{
    public interface IDiscountFactory : IFactory<Discount, DiscountDto>
    {
    }
}