using Otter.Business.Definitions.Factories;
using Otter.Business.Dtos;
using Otter.Common.Entities;

namespace Otter.Business.Implementations.Factories
{
    public class AgentFactory : BaseFactory<Agent, AgentDto>, IAgentFactory
    {
    }
}