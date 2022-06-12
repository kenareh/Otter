using System;
using Otter.Common.Entities.BaseEntities;
using Otter.Common.Enums;

namespace Otter.Common.Entities
{
    public class Policy : BaseEntity<long>
    {
        public Guid Guid { get; set; }
        public long Price { get; set; }
        public bool GuarantyStatus { get; set; }
        public string Mobile { get; set; }

        public string Otp { get; set; }
        public DateTime OtpExpiredTime { get; set; }

        public string Imei { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string NationalCode { get; set; }
        public string BirthDateString { get; set; }
        public string BirthDate { get; set; }
        public string Address { get; set; }

        public PolicyState PolicyState { get; set; }
        public long ModelId { get; set; }
        public long CityId { get; set; }
        public virtual Model Model { get; set; }
        public virtual City City { get; set; }
    }
}