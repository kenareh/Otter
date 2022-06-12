using System.ComponentModel.DataAnnotations;
using Otter.Common.Entities.BaseEntities;

namespace Otter.Common.Entities
{
    public class Currency : BaseEntity<long>
    {
        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(50)]
        public string LatinName { get; set; }
    }
}