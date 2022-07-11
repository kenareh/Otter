namespace Otter.Business.Dtos.Payment
{
    public class PaymentRequestResultDto
    {
        public string Token { get; set; }
        public string PaymentUrl { get; set; }
        public string PaymentId { get; set; }
        public string MerchantId { get; set; }
    }
}