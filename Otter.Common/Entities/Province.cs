using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Otter.Common.Entities.BaseEntities;

namespace Otter.Common.Entities
{
    [Table("Provinces", Schema = "Base")]
    public class Province : BaseEntity<long>
    {
        [MaxLength(100)]
        public string Name { get; set; }

        public virtual List<City> Cities { get; set; }
    }
}