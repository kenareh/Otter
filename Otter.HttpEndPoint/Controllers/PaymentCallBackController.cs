using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Otter.Business.Definitions.Services;
using Otter.Common.Exceptions;

namespace Otter.HttpEndPoint.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/payment-callback")]
    public class PaymentCallBackController : Controller
    {
        private IConfiguration _configuration;
        private ILogger<PaymentCallBackController> _logger;
        private IPaymentService _paymentService;

        public PaymentCallBackController(IPaymentService paymentService, ILogger<PaymentCallBackController> logger, IConfiguration configuration)
        {
            _paymentService = paymentService;
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult<string>> PostPayCallBackAsync(Guid guid)
        {
            try
            {
                var result = await _paymentService.CallBackAsync(guid);
                return Redirect(result);
            }
            catch (EntityNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest("خطای غیر منتظره رخ داده است");
            }
        }
    }
}