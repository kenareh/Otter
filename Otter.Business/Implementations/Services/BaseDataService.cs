using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Otter.Business.Definitions.Factories;
using Otter.Business.Definitions.Services;
using Otter.Business.Dtos;
using Otter.DataAccess;

namespace Otter.Business.Implementations.Services
{
    public class BaseDataService : IBaseDataService
    {
        private IUnitOfWork _unitOfWork;
        private IProvinceFactory _provinceFactory;
        private ICityFactory _cityFactory;
        private IBrandFactory _brandFactory;

        public BaseDataService(IUnitOfWork unitOfWork, IProvinceFactory provinceFactory, ICityFactory cityFactory, IBrandFactory brandFactory)
        {
            _unitOfWork = unitOfWork;
            _provinceFactory = provinceFactory;
            _cityFactory = cityFactory;
            _brandFactory = brandFactory;
        }

        public List<ProvinceDto> GetProvinces()
        {
            var provinces = _unitOfWork.ProvinceRepository.GetAll().ToList();
            return _provinceFactory.CreateDto(provinces).ToList();
        }

        public List<CityDto> GetCities(long provinceId)
        {
            var cities = _unitOfWork.CityRepository.Find(p => p.ProvinceId == provinceId).ToList();
            return _cityFactory.CreateDto(cities).ToList();
        }

        public List<BrandDto> GetBrands()
        {
            var brands = _unitOfWork.BrandRepository.GetAll().Include(p => p.Models).ToList();

            return _brandFactory.CreateDto(brands).ToList();
        }
    }
}