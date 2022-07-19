using Otter.Business.Dtos;
using Otter.Common.Entities;

namespace Otter.Business.Definitions.Factories
{
    public interface IPolicyFactory : IFactory<Policy, PolicyDto>
    {
        Policy CreateEntityFromBasicInformation(BasicInformationRequestDto dto);

        PolicyFullDto CreateFullDto(Policy entity);
    }
}