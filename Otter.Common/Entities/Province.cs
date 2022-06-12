using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Otter.Common.Entities.BaseEntities;

namespace Otter.Common.Entities
{
    [Table("Provinces", Schema = "Base")]
    public class Province : BaseEntity<long>
    {
        public string Name { get; set; }
        public virtual List<City> Cities { get; set; }
    }
}