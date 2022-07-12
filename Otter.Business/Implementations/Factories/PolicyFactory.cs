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
        private ICityFactory _cityFactory;
        private IModelFactory _modelFactory;
        private IProvinceFactory _provinceFactory;
        private IBrandFactory _brandFactory;

        public PolicyFactory(ICityFactory cityFactory, IModelFactory modelFactory, IProvinceFactory provinceFactory, IBrandFactory brandFactory)
        {
            _cityFactory = cityFactory;
            _modelFactory = modelFactory;
            _provinceFactory = provinceFactory;
            _brandFactory = brandFactory;
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