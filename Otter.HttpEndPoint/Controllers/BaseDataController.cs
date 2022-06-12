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
        [Route("provinces")]
        public ActionResult<PolicyDto> GetProvinces()
        {
            return Ok(_baseDataService.GetProvinces());
        }

        [HttpGet]
        [Route("provinces/{provinceId}/cities")]
        public ActionResult<PolicyDto> GetProvincesCities(long provinceId)
        {
            return Ok(_baseDataService.GetCities(provinceId));
        }
    }
}