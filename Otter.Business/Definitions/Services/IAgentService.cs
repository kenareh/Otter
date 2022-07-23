using System.Collections.Generic;
using Otter.Business.Dtos;
using Otter.Common.Entities;

namespace Otter.Business.Definitions.Services
{
    public interface IAgentService
    {
        Agent Get(string agentCode);

        AgentDto Get(long id);

        List<AgentDto> Get();

        AgentDto Add(AgentDto dto);

        AgentDto Edit(AgentDto dto);

        void Delete(long id);
    }
}