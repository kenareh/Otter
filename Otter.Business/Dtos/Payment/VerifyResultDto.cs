using System;

namespace Otter.Business.Dtos.Payment
{
    public class VerifyResultDto
    {
        public string RetrievalReferenceNumber { get; set; }
        public string SystemTraceAuditNumber { get; set; }
        public string PayerCard { get; set; }
        public DateTime DateTime { get; set; }
    }
}