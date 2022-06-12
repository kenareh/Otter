using System.ComponentModel.DataAnnotations.Schema;
using Otter.Common.Entities.BaseEntities;

namespace Otter.Common.Entities
{
    [Table("Models", Schema = "Base")]
    public class Model : BaseEntity<long>
    {
        public string Name { get; set; }

        public long BrandId { get; set; }
        public virtual Brand Brand { get; set; }
    }
}