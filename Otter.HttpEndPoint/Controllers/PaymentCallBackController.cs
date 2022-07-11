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

        [Route("")]
        public async Task<ActionResult> IranKishCallBack(string token, string responseCode,
            string acceptorId, string amount, string paymentId,
            string requestId, string retrievalReferenceNumber, string systemTraceAuditNumber, string maskedPan)
        {
            try
            {
                var result = await _paymentService.VerifyAsync(token, responseCode, acceptorId, amount, paymentId, requestId, retrievalReferenceNumber, systemTraceAuditNumber, maskedPan);
                return Redirect(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return BadRequest("خطای غیر منتظره رخ داده است");
            }
        }
    }
}