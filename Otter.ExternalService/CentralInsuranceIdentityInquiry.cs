using System;
using System.Threading.Tasks;
using Otter.ExternalService.Dto;
using Otter.ExternalService.Utilities;

namespace Otter.ExternalService
{
    public class CentralInsuranceIdentityInquiry : ICentralInsuranceIdentityInquiry
    {
        #region Fields

        private readonly IInternalClientService _internalClientService;

        #endregion Fields

        #region Constructor

        public CentralInsuranceIdentityInquiry(IInternalClientService internalClientService)
        {
            _internalClientService = internalClientService;
        }

        #endregion Constructor

        #region Methods

        public async Task<CentralInsuranceIdentityInquiryResultDto> InquiryAsync(string nationalCode, int birthdateYear)
        {
            var path = _internalClientService.GetPath(ServiceUrl.ExternalService) + $"central-insurance/identity-inquiry/national-code/{nationalCode}/birthdate-year/{birthdateYear}";
            var result = await _internalClientService.GetAsync<CentralInsuranceIdentityInquiryResultDto>(path);
            return result;
        }

        #endregion Methods
    }
}