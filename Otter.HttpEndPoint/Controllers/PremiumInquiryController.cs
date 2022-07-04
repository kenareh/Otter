using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Otter.Business.Definitions.Services;
using Otter.Business.Dtos;
using Otter.Common.Exceptions;
using Otter.Common.Tools;

namespace Otter.HttpEndPoint.Controllers
{
    [Route("api/premium-inquiry")]
    [ApiController]
    public class PremiumInquiryController : ControllerBase
    {
        private IPremiumInquiryService _premiumInquiryService;

        public PremiumInquiryController(IPremiumInquiryService premiumInquiryService)
        {
            _premiumInquiryService = premiumInquiryService;
        }

        [HttpPost]
        [Route("")]
        public ActionResult<InquiryResultDto> Post(InquiryRequestDto dto)
        {
            try
            {
                var result = _premiumInquiryService.PremiumInquiry(dto, false);
                return Ok(result);
            }
            catch (EntityNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}