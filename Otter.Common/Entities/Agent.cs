using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Otter.Common.Entities.BaseEntities;

namespace Otter.Common.Entities
{
    public class Agent : BaseEntity<long>
    {
        [MaxLength(150)]
        public string Name { get; set; }

        [MaxLength(7)]
        public string Code { get; set; }

        public bool IsActive { get; set; }
        public DateTime InsertDate { get; set; }

        public List<Policy> Policies { get; set; }
    }
}