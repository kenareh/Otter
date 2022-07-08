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
    [Route("api/policies")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private IPolicyService _policyService;
        private ILogger<PolicyController> _logger;

        public PolicyController(IPolicyService policyService, ILogger<PolicyController> logger)
        {
            _policyService = policyService;
            _logger = logger;
        }

        [HttpGet]
        [Route("{guid}")]
        public ActionResult<PolicyDto> GetPolicy(Guid guid)
        {
            try
            {
                var result = _policyService.Get(guid);
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

        [HttpPost]
        [Route("basic-information")]
        public async Task<ActionResult<Guid>> PostBasicInformation(BasicInformationRequestDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var result = await _policyService.InsertBasicInformation(dto);
                        return Ok(result);
                    }
                    catch (EntityNotFoundException e)
                    {
                        return NotFound(e.Message);
                    }
                }

                return BadRequest(ModelState);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return BadRequest("خطای غیر منتظره رخ داده است");
            }
        }

        [HttpPut]
        [Route("{guid}/mobile-confirmation/{otp}")]
        public ActionResult<PolicyDto> MobileConfirmation(Guid guid, string otp)
        {
            try
            {
                var result = _policyService.MobileConfirmByOtp(guid, otp);
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

        [HttpPut]
        [Route("{guid}/mobile-confirmation/reissue-otp")]
        public async Task<ActionResult<PolicyDto>> ReissueOtpAsync(Guid guid)
        {
            try
            {
                await _policyService.ReissueOtpAsync(guid);
                return Ok();
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

        [HttpPut]
        [Route("{guid}/imei/{imei}")]
        public ActionResult<PolicyDto> Imei(Guid guid, string imei)
        {
            try
            {
                var result = _policyService.AddImeiFile(guid, imei);
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

        [HttpPut]
        [Route("{guid}/files/imei")]
        public ActionResult<PolicyDto> AddImeiFile(Guid guid, FilePolicyInsertDto dto)
        {
            try
            {
                var result = _policyService.AddImeiFile(guid, dto.Base64Image);
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
        [Route("{guid}/files/imei")]
        public ActionResult<PolicyDto> GetImeiFile(Guid guid)
        {
            try
            {
                var result = _policyService.GetImeiFile(guid);
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

        [HttpPut]
        [Route("{guid}/files/camera")]
        public ActionResult<PolicyDto> AddCameraFiles(Guid guid, FileCameraInsertDto dto)
        {
            try
            {
                var result = _policyService.AddCameraFiles(guid, dto.FrontCameraBase64Image, dto.BackCameraBase64Image);
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
        [Route("{guid}/files/camera")]
        public ActionResult<PolicyDto> GetCameraFiles(Guid guid)
        {
            try
            {
                var result = _policyService.GetCameraFiles(guid);
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

        [HttpPut]
        [Route("{guid}/files/box-image")]
        public ActionResult<PolicyDto> AddBoxImageFile(Guid guid, FilePolicyInsertDto dto)
        {
            try
            {
                var result = _policyService.AddBoxImageFile(guid, dto.Base64Image);
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
        [Route("{guid}/files/box-image")]
        public ActionResult<PolicyDto> GetBoxImageFile(Guid guid)
        {
            try
            {
                var result = _policyService.GetBoxImageFile(guid);
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
        [Route("{guid}/speaker-test/")]
        public ActionResult<Guid> GetSpeakerTestFileName(Guid guid)
        {
            try
            {
                var result = _policyService.GetSpeakerTestFileName(guid);
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

        [HttpPost]
        [Route("{guid}/speaker-test/{number}")]
        public ActionResult<bool> SpeakerTest(Guid guid, int number)
        {
            try
            {
                var result = _policyService.SpeakerTest(guid, number);
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

        [HttpPut]
        [Route("{guid}/files/microphone-test")]
        public ActionResult<PolicyDto> AddMicrophoneTest(Guid guid, FilePolicyInsertDto dto)
        {
            try
            {
                var result = _policyService.AddMicrophoneTestFile(guid, dto.Base64Image);
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
        [Route("{guid}/files/microphone-test")]
        public ActionResult<PolicyDto> GetMicrophoneTestFile(Guid guid)
        {
            try
            {
                var result = _policyService.GetMicrophoneTestFile(guid);
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

        [HttpPut]
        [Route("{guid}/screen-test")]
        public ActionResult<bool> ScreenTest(Guid guid)
        {
            try
            {
                var result = _policyService.ScreenTest(guid);
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

        [HttpPut]
        [Route("{guid}/personal-information")]
        public ActionResult<bool> InsertPersonalInformation(Guid guid, PersonalInfoDto dto)
        {
            try
            {
                var result = _policyService.InsertPersonalInformation(guid, dto);
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