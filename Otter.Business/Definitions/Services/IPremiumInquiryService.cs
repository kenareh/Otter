using Otter.Business.Dtos;

namespace Otter.Business.Definitions.Services
{
    public interface IPremiumInquiryService
    {
        InquiryResultDto PremiumInquiry(InquiryRequestDto dto);
    }
}