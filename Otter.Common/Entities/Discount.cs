using System;
using System.ComponentModel.DataAnnotations;
using Otter.Common.Entities.BaseEntities;
using Otter.Common.Enums;

namespace Otter.Common.Entities
{
    public class Discount : BaseEntity<long>
    {
        [MaxLength(50)]
        public string Code { get; set; }

        public DiscountType DiscountType { get; set; }
        public long? AbsoluteDiscount { get; set; }
        public int? PercentDiscount { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public DiscountUsageType DiscountUsageType { get; set; }
        public int? LimitedCount { get; set; }
        public int RemainingLimitedCount { get; set; }

        public bool IsActive { get; set; }
    }
}