namespace Otter.Business.Dtos.Payment
{
    public class TokenResultDto
    {
        public string ResponseCode { get; set; }
        public object Description { get; set; }
        public bool Status { get; set; }
        public TokenResultData Result { get; set; }
    }

    public class TokenResultData
    {
        public string Token { get; set; }
        public int InitiateTimeStamp { get; set; }
        public int ExpiryTimeStamp { get; set; }
        public string TransactionType { get; set; }
        public TokenResultBillInfo BillInfo { get; set; }
    }

    public class TokenResultBillInfo
    {
        public object BillId { get; set; }
        public object BillPaymentId { get; set; }
    }
}