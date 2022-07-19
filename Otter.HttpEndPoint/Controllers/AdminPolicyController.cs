using System;
using System.Threading.Tasks;
using ASP;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Otter.Business.Definitions.Services;
using Otter.Business.Dtos.Payment;
using Otter.Common.Exceptions;

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
        public ActionResult<PaymentRequestResultDto> InsertPaymentRequestAsync(long id)
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
    }
}