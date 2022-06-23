using Otter.Common.Entities.BaseEntities;
using Otter.Common.Enums;

namespace Otter.Common.Entities
{
    public class PolicyFile : BaseEntity<long>
    {
        public PolicyFileType PolicyFileType { get; set; }
        public string Base64 { get; set; }

        public long PolicyId { get; set; }
        public virtual Policy Policy { get; set; }
    }
}