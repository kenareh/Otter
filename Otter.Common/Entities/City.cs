using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Otter.Common.Entities.BaseEntities;

namespace Otter.Common.Entities
{
    [Table("Cities", Schema = "Base")]
    public class City : BaseEntity<long>
    {
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string EnName { get; set; }

        public int Index { get; set; }
        public long ProvinceId { get; set; }
        public virtual Province Province { get; set; }
    }
}