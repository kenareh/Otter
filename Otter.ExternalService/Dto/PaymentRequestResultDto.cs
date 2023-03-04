using System;

namespace Otter.ExternalService.Dto
{
    public class PaymentRequestResultDto
    {
        public Guid Guid { get; set; }
        public string RedirectUrl { get; set; }
        public string Token { get; set; }
        public string PaymentUrl { get; set; }
        public string RequestId { get; set; }
        public string PaymentId { get; set; }
    }
}