using System.ComponentModel.DataAnnotations.Schema;
using Otter.Common.Entities.BaseEntities;

namespace Otter.Common.Entities
{
    [Table("Cities", Schema = "Base")]
    public class City : BaseEntity<long>
    {
        public string Name { get; set; }
        public long ProvinceId { get; set; }
        public virtual Province Province { get; set; }
    }
}