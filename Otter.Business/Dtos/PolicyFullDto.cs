﻿using System;
using System.Collections.Generic;
using Otter.Common.Entities;
using Otter.Common.Enums;

namespace Otter.Business.Dtos
{
    public class PolicyFullDto
    {
        public long Id { get; set; }

        public Guid Guid { get; set; }
        public long Price { get; set; }
        public bool GuarantyStatus { get; set; }

        public string Mobile { get; set; }

        public bool IsMobileConfirmed { get; set; }

        public string Otp { get; set; }

        public DateTime OtpExpiredTime { get; set; }

        public string Imei { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string NationalCode { get; set; }

        public string BirthDateString { get; set; }

        public DateTime BirthDate { get; set; }

        public string Address { get; set; }

        public long BasePremium { get; set; }
        public long FinalPremium { get; set; }
        public long Discount { get; set; }
        public string DiscountCode { get; set; }

        public double PremiumRate { get; set; }

        public int SpeakerTestAttempt { get; set; }
        public bool SpeakerTestState { get; set; }
        public bool MicrophoneTestState { get; set; }
        public bool ScreenTestState { get; set; }
        public string MarketerCode { get; set; }

        public BaseEnumDto PolicyState { get; set; }
        public long ModelId { get; set; }
        public long CityId { get; set; }

        public CityDto City { get; set; }
        public ModelDto Model { get; set; }
        public ProvinceDto Province { get; set; }
        public BrandDto Brand { get; set; }
        public SpeakerTestNumberDto SpeakerTestNumber { get; set; }

        public List<PolicyFileDto> PolicyFiles { get; set; }
    }
}