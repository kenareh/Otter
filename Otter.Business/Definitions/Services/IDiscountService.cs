using System.Collections.Generic;
using Otter.Business.Dtos.Discount;

namespace Otter.Business.Definitions.Services
{
    public interface IDiscountService
    {
        long Calculate(string discountCode, long basePremium, bool isActualUseForPolicy);

        DiscountDto Get(long id);

        List<DiscountDto> Get();

        void Insert(InsertDiscountDto dto);

        DiscountDto Update(UpdateDiscountDto dto);

        void Delete(long id);
    }
}