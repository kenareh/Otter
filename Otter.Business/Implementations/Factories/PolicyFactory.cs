using System;
using System.Linq;
using Otter.Business.Definitions.Factories;
using Otter.Business.Dtos;
using Otter.Common.Entities;
using Otter.Common.Enums;
using Otter.Common.Tools;

namespace Otter.Business.Implementations.Factories
{
    public class PolicyFactory : BaseFactory<Policy, PolicyDto>, IPolicyFactory
    {
        private ICityFactory _cityFactory;
        private IModelFactory _modelFactory;
        private IProvinceFactory _provinceFactory;
        private IBrandFactory _brandFactory;
        private ISpeakerTestNumberFactory _speakerTestNumberFactory;
        private IPolicyFileFactory _policyFileFactory;
        private IAgentFactory _agentFactory;

        public PolicyFactory(ICityFactory cityFactory, IModelFactory modelFactory, IProvinceFactory provinceFactory, IBrandFactory brandFactory, ISpeakerTestNumberFactory speakerTestNumberFactory, IPolicyFileFactory policyFileFactory, IAgentFactory agentFactory)
        {
            _cityFactory = cityFactory;
            _modelFactory = modelFactory;
            _provinceFactory = provinceFactory;
            _brandFactory = brandFactory;
            _speakerTestNumberFactory = speakerTestNumberFactory;
            _policyFileFactory = policyFileFactory;
            _agentFactory = agentFactory;
        }

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

        public PolicyFullDto CreateFullDto(Policy entity)
        {
            var dto = ObjectCopy.ShallowCopy<PolicyFullDto, Policy>(entity);
            dto.PolicyState = entity.PolicyState.ToBaseEnumDto();

            if (entity.City != null)
            {
                dto.City = _cityFactory.CreateDto(entity.City);
                if (entity.City.Province != null)
                {
                    dto.Province = _provinceFactory.CreateDto(entity.City.Province);
                }
            }
            if (entity.Model != null)
            {
                dto.Model = _modelFactory.CreateDto(entity.Model);
                if (entity.Model.Brand != null)
                {
                    dto.Brand = _brandFactory.CreateDto(entity.Model.Brand);
                }
            }
            if (entity.SpeakerTestNumber != null)
            {
                dto.SpeakerTestNumber = _speakerTestNumberFactory.CreateDto(entity.SpeakerTestNumber);
            }
            if (entity.Agent != null)
            {
                dto.Agent = _agentFactory.CreateDto(entity.Agent);
            }

            if (entity.PolicyFiles.Any())
            {
                dto.PolicyFiles = _policyFileFactory.CreateDto(entity.PolicyFiles).ToList();
            }

            return dto;
        }

        public override PolicyDto CreateDto(Policy entity)
        {
            var dto = base.CreateDto(entity);

            dto.PolicyState = entity.PolicyState.ToBaseEnumDto();

            if (entity.City != null)
            {
                dto.City = _cityFactory.CreateDto(entity.City);
                if (entity.City.Province != null)
                {
                    dto.Province = _provinceFactory.CreateDto(entity.City.Province);
                }
            }
            if (entity.Model != null)
            {
                dto.Model = _modelFactory.CreateDto(entity.Model);
                if (entity.Model.Brand != null)
                {
                    dto.Brand = _brandFactory.CreateDto(entity.Model.Brand);
                }
            }
            return dto;
        }
    }
}