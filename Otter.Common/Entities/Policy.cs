using System;
using System.Collections.Generic;
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

        public bool IsMobileConfirmed { get; set; }

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

        public DateTime BirthDate { get; set; }

        [MaxLength(500)]
        public string Address { get; set; }

        public PolicyState PolicyState { get; set; }

        public long BasePremium { get; set; }
        public long FinalPremium { get; set; }
        public long Discount { get; set; }

        [MaxLength(20)]
        public string DiscountCode { get; set; }

        public double PremiumRate { get; set; }

        public int SpeakerTestAttempt { get; set; }
        public bool SpeakerTestState { get; set; }
        public bool MicrophoneTestState { get; set; }
        public bool ScreenTestState { get; set; }

        public bool ImeiFileState { get; set; }
        public bool PhoneFileBoxState { get; set; }
        public bool CameraFileState { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public long ModelId { get; set; }
        public long? CityId { get; set; }
        public long SpeakerTestNumberId { get; set; }

        [MaxLength(10)]
        public string MarketerCode { get; set; }

        public bool IsSendTrackingSms { get; set; }

        public virtual Model Model { get; set; }
        public virtual City City { get; set; }
        public virtual SpeakerTestNumber SpeakerTestNumber { get; set; }

        public List<PolicyFile> PolicyFiles { get; set; }
        public List<Payment> Payments { get; set; }
    }
}