using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Otter.Business.Definitions.Services;
using Otter.Business.Dtos;
using Otter.Common.Exceptions;
using Otter.Common.Tools;

namespace Otter.HttpEndPoint.Controllers
{
    [Route("api/payment")]
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
        [Route("")]
        public async Task<ActionResult<object>> Get(string requestId, string paymentId)
        {
            requestId = new Random().Next(50000, 9000000).ToString();
            paymentId = new Random().Next(50000, 9000000).ToString();
            await _paymentService.GetTokenAsync(100000, requestId, paymentId, "https://tejaratnoins.ir");
            return Ok();
        }
    }
}