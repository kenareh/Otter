namespace Otter.Business.Definitions.Services
{
    public interface IDiscountService
    {
        long Calculate(string discountCode, long basePremium, bool isActualUseForPolicy);
    }
}