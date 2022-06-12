using System.Collections.Generic;
using Otter.Business.Dtos;

namespace Otter.Business.Definitions.Services
{
    public interface IBaseDataService
    {
        List<ProvinceDto> GetProvinces();

        List<CityDto> GetCities(long provinceId);
    }
}