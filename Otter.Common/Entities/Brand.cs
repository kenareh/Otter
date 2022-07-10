using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Otter.Common.Entities.BaseEntities;

namespace Otter.Common.Entities
{
    [Table("Brands", Schema = "Base")]
    public class Brand : BaseEntity<long>
    {
        public string Name { get; set; }

        [MaxLength(100)]
        public string EnName { get; set; }

        public int Index { get; set; }

        public List<Model> Models { get; set; }
    }
}