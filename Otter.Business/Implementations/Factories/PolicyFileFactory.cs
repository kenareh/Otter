using Otter.Business.Definitions.Factories;
using Otter.Business.Dtos;
using Otter.Common.Entities;
using Otter.Common.Tools;

namespace Otter.Business.Implementations.Factories
{
    public class PolicyFileFactory : BaseFactory<PolicyFile, PolicyFileDto>, IPolicyFileFactory
    {
        public override PolicyFileDto CreateDto(PolicyFile entity)
        {
            var dto = base.CreateDto(entity);

            dto.PolicyFileType = entity.PolicyFileType.ToBaseEnumDto();

            return dto;
        }
    }
}