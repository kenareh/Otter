using System;
using Otter.Business.Definitions.Services;
using Otter.Business.Dtos;

namespace Otter.Business.Implementations.Services
{
    public class PremiumInquiryService : IPremiumInquiryService
    {
        private IDiscountService _discountService;

        public PremiumInquiryService(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        public InquiryResultDto PremiumInquiry(InquiryRequestDto dto)
        {
            var basePremium = Convert.ToInt64(dto.Price * 0.03); //todo : from database

            var discount = _discountService.Calculate(dto.DiscountCode, basePremium);

            return new InquiryResultDto()
            {
                FinalPremium = basePremium - discount,
                BasePremium = basePremium,
                Discount = discount,
                PremiumRate = .03//todo : from database
            };
        }
    }
}