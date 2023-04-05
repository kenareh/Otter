using System.Threading.Tasks;
using Otter.ExternalService.Dto;

namespace Otter.ExternalService
{
    public interface ICentralInsuranceIdentityInquiry
    {
        #region Methods

        Task<CentralInsuranceIdentityInquiryResultDto> InquiryAsync(string nationalCode, int birthdateYear);

        #endregion Methods
    }
}