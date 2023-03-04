namespace Otter.ExternalService.Dto
{
    public class PaymentRequestDto
    {
        public string TerminalId { get; set; }
        public string CallBackRedirectUrl { get; set; }
        public long Amount { get; set; }
        public string PaymentNo { get; set; }
    }
}