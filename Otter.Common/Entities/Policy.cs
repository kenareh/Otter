using System;
using System.ComponentModel.DataAnnotations;
using Otter.Common.Entities.BaseEntities;
using Otter.Common.Enums;

namespace Otter.Common.Entities
{
    public class Policy : BaseEntity<long>
    {
        public Guid Guid { get; set; }
        public long Price { get; set; }
        public bool GuarantyStatus { get; set; }

        [MaxLength(12)]
        public string Mobile { get; set; }

        [MaxLength(6)]
        public string Otp { get; set; }

        public DateTime OtpExpiredTime { get; set; }

        [MaxLength(50)]
        public string Imei { get; set; }

        [MaxLength(100)]
        public string Firstname { get; set; }

        [MaxLength(100)]
        public string Lastname { get; set; }

        [MaxLength(10)]
        public string NationalCode { get; set; }

        [MaxLength(50)]
        public string BirthDateString { get; set; }

        [MaxLength(50)]
        public DateTime BirthDate { get; set; }

        [MaxLength(500)]
        public string Address { get; set; }

        public PolicyState PolicyState { get; set; }
        public long ModelId { get; set; }
        public long CityId { get; set; }
        public virtual Model Model { get; set; }
        public virtual City City { get; set; }
    }
}