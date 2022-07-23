using System;

namespace Otter.Business.Dtos
{
    public class AgentDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
    }
}