namespace Otter.Business.Dtos
{
    public class InquiryResultDto
    {
        public long BasePremium { get; set; }
        public long FinalPremium { get; set; }
        public long Discount { get; set; }
        public double PremiumRate { get; set; }
    }
}