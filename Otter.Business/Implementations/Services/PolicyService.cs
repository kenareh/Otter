using Otter.Business.Definitions.Factories;
using Otter.Business.Definitions.Services;
using Otter.Business.Dtos;
using Otter.DataAccess;

namespace Otter.Business.Implementations.Services
{
    public class PolicyService : IPolicyService
    {
        private IUnitOfWork _unitOfWork;
        private IPolicyFactory _policyFactory;

        public PolicyService(IUnitOfWork unitOfWork, IPolicyFactory policyFactory)
        {
            _unitOfWork = unitOfWork;
            _policyFactory = policyFactory;
        }

        public PolicyDto InsertBasicInformation(BasicInformationRequestDto dto)
        {
            var policy = _policyFactory.CreateEntityFromBasicInformation(dto);

            _unitOfWork.PolicyRepository.Add(policy);
            _unitOfWork.Commit();

            return _policyFactory.CreateDto(policy);
        }
    }
}