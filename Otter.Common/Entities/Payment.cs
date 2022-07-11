using System;
using System.ComponentModel.DataAnnotations;
using Otter.Common.Entities.BaseEntities;

namespace Otter.Common.Entities
{
    public class Payment : BaseEntity<long>
    {
        public long PremiumAmount { get; set; }

        [Required]
        [MaxLength(30)]
        public string RequestId { get; set; }

        [MaxLength(11)]
        public string PaymentId { get; set; }

        [MaxLength(50)]
        public string Token { get; set; }

        public long PolicyId { get; set; }
        public Policy Policy { get; set; }
        public DateTime InsertDate { get; set; }

        public DateTime? VerifyDate { get; set; }

        [MaxLength(100)]
        public string PayerCard { get; set; }

        [MaxLength(100)]
        public string RetrievalReferenceNumber { get; set; }

        [MaxLength(100)]
        public string SystemTraceAuditNumber { get; set; }

        public bool? IsSuccessful { get; set; }

        public Guid Guid { get; set; }

        [MaxLength(300)]
        public string ErrorMessage { get; set; }
    }
}