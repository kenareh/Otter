using System;
using System.ComponentModel.DataAnnotations;
using Otter.Common.Entities.BaseEntities;

namespace Otter.Common.Entities
{
    public class Log : BaseEntity<long>
    {
        [Required]
        [MaxLength(50)]
        public string Application { get; set; }

        [Required]
        [MaxLength(50)]
        public string MachineName { get; set; }

        public DateTime Logged { get; set; }

        [Required]
        [MaxLength(50)]
        public string Level { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        [MaxLength(250)]
        public string Logger { get; set; }

        public string Callsite { get; set; }
        public string Exception { get; set; }
    }
}