namespace Otter.Business.Dtos.Payment
{
    public class IranKishVerifyRequestDto
    {
        public string TerminalId { get; set; }

        public string RetrievalReferenceNumber { get; set; }

        public string SystemTraceAuditNumber { get; set; }

        public string TokenIdentity { get; set; }
    }
}