using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Otter.Business.Definitions.Services;
using Otter.Business.Dtos;
using Otter.Business.Dtos.Payment;
using Otter.Common.Exceptions;

namespace Otter.HttpEndPoint.Controllers
{
    [Route("api/admin/payments")]
    public class AdminPaymentController : AuthorizedController
    {
        private ILogger<AdminPaymentController> _logger;
        private IPaymentService _paymentService;

        public AdminPaymentController(ILogger<AdminPaymentController> logger, IPaymentService paymentService)
        {
            _logger = logger;
            _paymentService = paymentService;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<PaymentDto> Get(long id)
        {
            try
            {
                var result = _paymentService.Get(id);
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
        [Route("policy-id/{policyId}")]
        public ActionResult<List<PaymentDto>> GetPaymentsByPolicyId(long policyId)
        {
            try
            {
                var result = _paymentService.GetByPolicyId(policyId);
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
        public ActionResult<PaymentDto> Get()
        {
            try
            {
                var result = _paymentService.Get();
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return BadRequest("خطای غیر منتظره رخ داده است");
            }
        }
    }
}