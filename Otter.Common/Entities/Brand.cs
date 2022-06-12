using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Otter.Common.Entities.BaseEntities;

namespace Otter.Common.Entities
{
    [Table("Brands", Schema = "Base")]
    public class Brand : BaseEntity<long>
    {
        public string Name { get; set; }

        public List<Model> Models { get; set; }
    }
}