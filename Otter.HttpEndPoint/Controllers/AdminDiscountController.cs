using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Otter.Business.Definitions.Services;
using Otter.Business.Dtos.Discount;
using Otter.Common.Exceptions;
using Otter.HttpEndPoint.Attributes;

namespace Otter.HttpEndPoint.Controllers
{
    [Route("api/admin/discounts")]
    [ApiAuthorization("mobile-insurance-admin")]
    public class AdminDiscountController : AuthorizedController
    {
        private ILogger<AdminDiscountController> _logger;
        private IDiscountService _discountService;

        public AdminDiscountController(ILogger<AdminDiscountController> logger, IDiscountService discountService)
        {
            _logger = logger;
            _discountService = discountService;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<DiscountDto> Get(long id)
        {
            try
            {
                var result = _discountService.Get(id);

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
        public ActionResult<DiscountDto> Get()
        {
            try
            {
                var result = _discountService.Get();

                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return BadRequest("خطای غیر منتظره رخ داده است");
            }
        }

        [HttpPost]
        [Route("")]
        public ActionResult Post(InsertDiscountDto dto)
        {
            try
            {
                _discountService.Insert(dto);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return BadRequest("خطای غیر منتظره رخ داده است");
            }
        }

        [HttpPut]
        [Route("")]
        public ActionResult Put(UpdateDiscountDto dto)
        {
            try
            {
                var result = _discountService.Update(dto);
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

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(long id)
        {
            try
            {
                _discountService.Delete(id);
                return Ok();
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