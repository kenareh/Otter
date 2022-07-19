using System;
using Otter.Common.Enums;

namespace Otter.Business.Dtos.Discount
{
    public class InsertDiscountDto
    {
        public int Count { get; set; }

        public DiscountType DiscountType { get; set; }
        public long? AbsoluteDiscount { get; set; }
        public int? PercentDiscount { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public DiscountUsageType DiscountUsageType { get; set; }
        public int? LimitedCount { get; set; }
        public int RemainingLimitedCount { get; set; }
    }
}