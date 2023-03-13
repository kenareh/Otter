using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Otter.Business.Definitions.Services;
using Otter.Business.Dtos;
using Otter.Common.Exceptions;
using Otter.Common.Tools;
using Otter.HttpEndPoint.Attributes;

namespace Otter.HttpEndPoint.Controllers
{
    [Route("api/admin/policies")]
    public class AdminPolicyController : AuthorizedController
    {
        private ILogger<AdminPolicyController> _logger;
        private IPolicyService _policyService;

        public AdminPolicyController(IPolicyService policyService, ILogger<AdminPolicyController> logger)
        {
            _policyService = policyService;
            _logger = logger;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<PolicyFullDto> Get(long id)
        {
            try
            {
                var result = _policyService.GetFull(id);
                return Ok(result);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return BadRequest("خطای غیر منتظره رخ داده است");
            }
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<PolicyDto>> Get()
        {
            try
            {
                var result = _policyService.Get();
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return BadRequest("خطای غیر منتظره رخ داده است");
            }
        }

        [HttpPost]
        [Route("{id}/validations")]
        public ActionResult<FailedStateValidationDto> Validation(long id, FailedStateValidationDto dto)
        {
            try
            {
                var result = _policyService.ValidateAsync(id, dto);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return BadRequest("خطای غیر منتظره رخ داده است");
            }
        }

        [HttpPost]
        [Route("proposals/ready-for-issue/download")]
        public ActionResult DownloadReadyForIssueProposals(FilterRequestDto dto)
        {
            try
            {
                var date = JalaliCalendar.MiladiToShamsiDate(DateTime.Now).Replace("/", string.Empty);
                var fileName = $"Proposals_{date}";

                byte[] data = _policyService.GetExcelPoliciesForIssue(dto, fileName);

                return File(data, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}