using System;
using Otter.Common.Enums;

namespace Otter.Business.Dtos.Discount
{
    public class DiscountDto
    {
        public long Id { get; set; }
        public string Code { get; set; }

        public BaseEnumDto DiscountType { get; set; }
        public long? AbsoluteDiscount { get; set; }
        public int? PercentDiscount { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public BaseEnumDto DiscountUsageType { get; set; }
        public int? LimitedCount { get; set; }
        public int RemainingLimitedCount { get; set; }

        public bool IsActive { get; set; }
    }
}