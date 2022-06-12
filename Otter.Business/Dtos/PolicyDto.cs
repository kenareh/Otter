using System;
using Otter.Common.Entities;
using Otter.Common.Enums;

namespace Otter.Business.Dtos
{
    public class PolicyDto
    {
        public long Id { get; set; }

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

        public BaseEnumDto PolicyState { get; set; }
        public long ModelId { get; set; }
        public long CityId { get; set; }
    }
}