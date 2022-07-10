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
        public string PayerCard { get; set; }
        public bool? IsSuccessful { get; set; }
    }
}