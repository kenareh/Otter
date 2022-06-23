using Otter.Common.Entities.BaseEntities;

namespace Otter.Common.Entities
{
    public class Configuration : BaseEntity<long>
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}