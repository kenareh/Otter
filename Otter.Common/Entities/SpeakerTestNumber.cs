using System;
using Otter.Common.Entities.BaseEntities;

namespace Otter.Common.Entities
{
    public class SpeakerTestNumber : BaseEntity<long>
    {
        public Guid FileName { get; set; }
        public int Number { get; set; }
        public int Order { get; set; }
    }
}