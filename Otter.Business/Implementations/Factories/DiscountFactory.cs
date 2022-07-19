using Otter.Business.Definitions.Factories;
using Otter.Business.Dtos.Discount;
using Otter.Common.Entities;
using Otter.Common.Tools;

namespace Otter.Business.Implementations.Factories
{
    public class DiscountFactory : BaseFactory<Discount, DiscountDto>, IDiscountFactory
    {
        public override DiscountDto CreateDto(Discount entity)
        {
            var dto = base.CreateDto(entity);

            dto.DiscountType = entity.DiscountType.ToBaseEnumDto();
            dto.DiscountUsageType = entity.DiscountUsageType.ToBaseEnumDto();

            return dto;
        }
    }
}