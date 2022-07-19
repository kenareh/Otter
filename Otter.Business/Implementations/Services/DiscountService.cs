using System;
using System.Collections.Generic;
using System.Linq;
using Otter.Business.Definitions.Factories;
using Otter.Business.Definitions.Services;
using Otter.Business.Dtos.Discount;
using Otter.Common.Entities;
using Otter.Common.Enums;
using Otter.Common.Exceptions;
using Otter.DataAccess;

namespace Otter.Business.Implementations.Services
{
    public class DiscountService : IDiscountService
    {
        private IUnitOfWork _unitOfWork;
        private IDiscountFactory _discountFactory;

        public DiscountService(IUnitOfWork unitOfWork, IDiscountFactory discountFactory)
        {
            _unitOfWork = unitOfWork;
            _discountFactory = discountFactory;
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

        public DiscountDto Get(long id)
        {
            var discount = _unitOfWork.DiscountRepository.Find(p => p.Id == id).FirstOrDefault();
            if (discount == null)
            {
                throw new EntityNotFoundException("کد تخفیف وارد شده معتبر نمی باشد");
            }

            return _discountFactory.CreateDto(discount);
        }

        public List<DiscountDto> Get()
        {
            var discounts = _unitOfWork.DiscountRepository.Find().ToList();
            return _discountFactory.CreateDto(discounts).ToList();
        }

        public void Insert(InsertDiscountDto dto)
        {
            for (int i = 0; i < dto.Count; i++)
            {
                var discount = new Discount()
                {
                    DiscountUsageType = dto.DiscountUsageType,
                    DiscountType = dto.DiscountType,
                    AbsoluteDiscount = dto.AbsoluteDiscount,
                    EndDate = dto.EndDate,
                    IsActive = true,
                    LimitedCount = dto.LimitedCount,
                    PercentDiscount = dto.PercentDiscount,
                    RemainingLimitedCount = dto.RemainingLimitedCount,
                    StartDate = dto.StartDate,
                    Code = GetNewDiscountCode(8)
                };
                _unitOfWork.DiscountRepository.Add(discount);
                _unitOfWork.Commit();
            }
        }

        public DiscountDto Update(UpdateDiscountDto dto)
        {
            var discount = _unitOfWork.DiscountRepository.Find(p => p.Id == dto.Id).FirstOrDefault();
            if (discount == null)
            {
                throw new EntityNotFoundException("کد تخفیف وارد شده معتبر نمی باشد");
            }
            discount.DiscountUsageType = dto.DiscountUsageType;
            discount.DiscountType = dto.DiscountType;
            discount.AbsoluteDiscount = dto.AbsoluteDiscount;
            discount.EndDate = dto.EndDate;
            discount.IsActive = true;
            discount.LimitedCount = dto.LimitedCount;
            discount.PercentDiscount = dto.PercentDiscount;
            discount.RemainingLimitedCount = dto.RemainingLimitedCount;
            discount.StartDate = dto.StartDate;

            return _discountFactory.CreateDto(discount);
        }

        public void Delete(long id)
        {
            var discount = _unitOfWork.DiscountRepository.Find(p => p.Id == id).FirstOrDefault();
            if (discount == null)
            {
                throw new EntityNotFoundException("کد تخفیف وارد شده معتبر نمی باشد");
            }
            discount.IsActive = false;
        }

        private string GetNewDiscountCode(int length)
        {
            string code = Guid.NewGuid().ToString().Replace("-", "").Substring(0, length);

            while (_unitOfWork.DiscountRepository.Find().Any(s => s.Code == code))
            {
                code = Guid.NewGuid().ToString().Replace("-", "").Substring(0, length);
            }

            return code;
        }
    }
}