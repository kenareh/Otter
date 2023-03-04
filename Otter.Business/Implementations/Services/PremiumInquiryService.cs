using System;
using Otter.Business.Definitions.Services;
using Otter.Business.Dtos;
using Otter.Common.Tools;

namespace Otter.Business.Implementations.Services
{
    public class PremiumInquiryService : IPremiumInquiryService
    {
        private IDiscountService _discountService;
        private IConfigurationService _configurationService;

        public PremiumInquiryService(IDiscountService discountService, IConfigurationService configurationService)
        {
            _discountService = discountService;
            _configurationService = configurationService;
        }

        public InquiryResultDto PremiumInquiry(InquiryRequestDto dto, bool isActualUseForPolicy)
        {
            var premiumRate = _configurationService.GetPremiumRate();
            var basePremium = Convert.ToInt64(dto.Price * premiumRate);

            long discount = 0;

            if (!dto.DiscountCode.IsNullOrEmpty())
            {
                discount = _discountService.Calculate(dto.DiscountCode, basePremium, isActualUseForPolicy);
            }

            var inquiry = new InquiryResultDto
            {
                FinalPremium = basePremium - discount,
                BasePremium = basePremium,
                Discount = discount,
                PremiumRate = premiumRate
            };

            var minimumPayableAmount = 50000;
            if (inquiry.FinalPremium < minimumPayableAmount && inquiry.FinalPremium >= 0)
            {
                var difference = minimumPayableAmount - inquiry.FinalPremium;

                inquiry.FinalPremium = minimumPayableAmount;
                inquiry.Discount = discount - difference;
            }
            else if (inquiry.FinalPremium < 0)
            {
                var negativeValue = -inquiry.FinalPremium;

                inquiry.Discount = discount - negativeValue;

                inquiry.FinalPremium = 0;
            }
            return inquiry;
        }
    }
}