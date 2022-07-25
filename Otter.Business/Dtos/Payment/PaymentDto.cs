using System;
using Otter.Common.Entities;

namespace Otter.Business.Dtos.Payment
{
    public class PaymentDto
    {
        public long Id { get; set; }
        public long PremiumAmount { get; set; }

        public string RequestId { get; set; }

        public string PaymentId { get; set; }

        public string Token { get; set; }

        public long PolicyId { get; set; }
        public PolicyDto Policy { get; set; }
        public DateTime InsertDate { get; set; }

        public DateTime? VerifyDate { get; set; }
        public string PayerCard { get; set; }
        public string RetrievalReferenceNumber { get; set; }
        public string SystemTraceAuditNumber { get; set; }
        public bool? IsSuccessful { get; set; }
        public Guid Guid { get; set; }
        public string ErrorMessage { get; set; }
    }
}