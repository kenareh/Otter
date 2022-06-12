using System.Collections.Generic;
using System.Linq;
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

        public BaseDataService(IUnitOfWork unitOfWork, IProvinceFactory provinceFactory, ICityFactory cityFactory)
        {
            _unitOfWork = unitOfWork;
            _provinceFactory = provinceFactory;
            _cityFactory = cityFactory;
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
    }
}