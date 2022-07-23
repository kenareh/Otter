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
    [Route("api/admin/agents")]
    public class AdminAgentController : AuthorizedController
    {
        private ILogger<AdminAgentController> _logger;
        private IAgentService _agentService;

        public AdminAgentController(ILogger<AdminAgentController> logger, IAgentService agentService)
        {
            _logger = logger;
            _agentService = agentService;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<AgentDto> Get(long id)
        {
            try
            {
                var result = _agentService.Get(id);
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
        public ActionResult<List<AgentDto>> Get()
        {
            try
            {
                var result = _agentService.Get();
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
        public ActionResult<AgentDto> Post(AgentDto dto)
        {
            try
            {
                var result = _agentService.Add(dto);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return BadRequest("خطای غیر منتظره رخ داده است");
            }
        }

        [HttpPut]
        [Route("")]
        public ActionResult<AgentDto> Put(AgentDto dto)
        {
            try
            {
                var result = _agentService.Edit(dto);
                return Ok(result);
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
                _agentService.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return BadRequest("خطای غیر منتظره رخ داده است");
            }
        }
    }
}