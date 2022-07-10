namespace Otter.Business.Dtos.Payment
{
    public class PaymentConfigurationDto
    {
        public string TerminalId { get; set; }
        public string AcceptorId { get; set; }
        public string PassPhrase { get; set; }
        public string RsaPublicKey { get; set; }
        public string AccountNumber { get; set; }
    }
}