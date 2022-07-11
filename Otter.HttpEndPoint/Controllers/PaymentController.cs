using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Otter.Business.Definitions.Services;
using Otter.Business.Dtos;
using Otter.Business.Dtos.Payment;
using Otter.Common.Exceptions;
using Otter.Common.Tools;

namespace Otter.HttpEndPoint.Controllers
{
    [Route("api/payments")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private ILogger<PolicyController> _logger;
        private IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService, ILogger<PolicyController> logger)
        {
            _paymentService = paymentService;
            _logger = logger;
        }

        [HttpGet]
        [Route("requests/policy-id/{policyGuid}")]
        public async Task<ActionResult<PaymentRequestResultDto>> InsertPaymentRequestAsync(Guid policyGuid)
        {
            try
            {
                var result = await _paymentService.InsertPaymentRequestAsync(policyGuid);
                return RedirectToAction("PaymentRedirect", "Home", result);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (BusinessViolatedException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return BadRequest("خطای غیر منتظره رخ داده است");
            }
        }

        [HttpGet]
        [Route("{guid}")]
        public ActionResult<PaymentDto> Get(Guid guid)
        {
            try
            {
                var result = _paymentService.Get(guid);
                return Ok(result);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (BusinessViolatedException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return BadRequest("خطای غیر منتظره رخ داده است");
            }
        }
    }
}