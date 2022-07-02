using System.Linq;
using Otter.Business.Definitions.Factories;
using Otter.Business.Dtos;
using Otter.Common.Entities;

namespace Otter.Business.Implementations.Factories
{
    public class BrandFactory : BaseFactory<Brand, BrandDto>, IBrandFactory
    {
        private IModelFactory _modelFactory;

        public BrandFactory(IModelFactory modelFactory)
        {
            _modelFactory = modelFactory;
        }

        public override BrandDto CreateDto(Brand entity)
        {
            var dto = base.CreateDto(entity);

            if (entity.Models != null)
            {
                dto.Models = _modelFactory.CreateDto(entity.Models).ToList();
            }
            return dto;
        }
    }
}