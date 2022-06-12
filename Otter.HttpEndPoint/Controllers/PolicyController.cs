using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Otter.Business.Definitions.Services;
using Otter.Business.Dtos;
using Otter.Common.Tools;

namespace Otter.HttpEndPoint.Controllers
{
    [Route("api/policies")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private IPolicyService _policyService;

        public PolicyController(IPolicyService policyService)
        {
            _policyService = policyService;
        }

        [HttpPost]
        [Route("basic-information")]
        public ActionResult<PolicyDto> PostBasicInformation(BasicInformationRequestDto dto)
        {
            if (ModelState.IsValid)
            {
                var result = _policyService.InsertBasicInformation(dto);
                return Ok(result);
            }

            return BadRequest(ModelState);
        }
    }
}