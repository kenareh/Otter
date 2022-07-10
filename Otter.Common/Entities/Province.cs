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

        [MaxLength(100)]
        public string EnName { get; set; }

        public int Index { get; set; }

        public virtual List<City> Cities { get; set; }
    }
}