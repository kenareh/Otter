using System;
using Otter.Business.Definitions.Factories;
using Otter.Business.Dtos;
using Otter.Common.Entities;
using Otter.Common.Enums;
using Otter.Common.Tools;

namespace Otter.Business.Implementations.Factories
{
    public class PolicyFactory : BaseFactory<Policy, PolicyDto>, IPolicyFactory
    {
        public Policy CreateEntityFromBasicInformation(BasicInformationRequestDto dto)
        {
            var policy = new Policy()
            {
                Mobile = dto.Mobile,
                ModelId = dto.ModelId,
                Guid = Guid.NewGuid(),
                GuarantyStatus = dto.GuarantyStatus,
                Price = dto.Price,
                IsMobileConfirmed = false
            };

            return policy;
        }

        public override PolicyDto CreateDto(Policy entity)
        {
            var dto = base.CreateDto(entity);

            dto.PolicyState = entity.PolicyState.ToBaseEnumDto();

            return dto;
        }
    }
}