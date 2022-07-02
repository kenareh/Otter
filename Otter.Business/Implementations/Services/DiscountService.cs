using System;
using System.Linq;
using Otter.Business.Definitions.Services;
using Otter.Common.Entities;
using Otter.Common.Enums;
using Otter.Common.Exceptions;
using Otter.DataAccess;

namespace Otter.Business.Implementations.Services
{
    public class DiscountService : IDiscountService
    {
        private IUnitOfWork _unitOfWork;

        public DiscountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public long Calculate(string discountCode, long basePremium, bool isActualUseForPolicy)
        {
            var discount = _unitOfWork.DiscountRepository.Find(p => p.Code == discountCode &&
                                                                          p.IsActive)
                .FirstOrDefault();

            if (discount == null)
            {
                throw new EntityNotFoundException("کد تخفیف وارد شده معتبر نمی باشد");
            }

            if (discount.StartDate.HasValue && discount.StartDate.Value > DateTime.Now)
            {
                throw new EntityNotFoundException("کد تخفیف وارد شده معتبر نمی باشد");
            }

            if (discount.EndDate.HasValue && discount.EndDate.Value < DateTime.Now)
            {
                throw new EntityNotFoundException("کد تخفیف وارد شده معتبر نمی باشد");
            }

            if (discount.DiscountUsageType == DiscountUsageType.Limited)
            {
                if (discount.RemainingLimitedCount <= 0)
                {
                    throw new EntityNotFoundException("کد تخفیف وارد شده معتبر نمی باشد");
                }
            }

            if (isActualUseForPolicy)
            {
                discount.RemainingLimitedCount--;
                _unitOfWork.Commit();
            }

            long discountValue = 0;
            if (discount.DiscountType == DiscountType.Percentage)
            {
                if (!discount.PercentDiscount.HasValue)
                {
                    throw new EntityNotFoundException("کد تخفیف وارد شده معتبر نمی باشد");
                }
                return basePremium * discount.PercentDiscount.Value / 100;
            }

            if (discount.DiscountType == DiscountType.Absolute)
            {
                if (!discount.AbsoluteDiscount.HasValue)
                {
                    throw new EntityNotFoundException("کد تخفیف وارد شده معتبر نمی باشد");
                }
                return discount.AbsoluteDiscount.Value;
            }

            return discountValue;
        }
    }
}