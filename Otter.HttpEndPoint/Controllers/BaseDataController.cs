using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Otter.Business.Definitions.Services;
using Otter.Business.Dtos;
using Otter.Common.Tools;

namespace Otter.HttpEndPoint.Controllers
{
    [Route("api/base-data")]
    [ApiController]
    public class BaseDataController : ControllerBase
    {
        private IBaseDataService _baseDataService;

        public BaseDataController(IBaseDataService baseDataService)
        {
            _baseDataService = baseDataService;
        }

        [HttpGet]
        [Route("brands")]
        public ActionResult<List<BrandDto>> GetBrands()
        {
            return Ok(_baseDataService.GetBrands());
        }

        [HttpGet]
        [Route("provinces")]
        public ActionResult<List<ProvinceDto>> GetProvinces()
        {
            return Ok(_baseDataService.GetProvinces());
        }

        [HttpGet]
        [Route("provinces/{provinceId}/cities")]
        public ActionResult<List<CityDto>> GetProvincesCities(long provinceId)
        {
            return Ok(_baseDataService.GetCities(provinceId));
        }
    }
}