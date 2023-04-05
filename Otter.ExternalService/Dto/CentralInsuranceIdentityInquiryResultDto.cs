using System.Collections.Generic;
using Otter.Common.Enums;

namespace Otter.ExternalService.Dto
{
    public class CentralInsuranceIdentityInquiryResultDto
    {
        #region Properties

        public long NationalCode { get; set; } //Nin
        public string Name { get; set; }
        public string Family { get; set; }
        public string FatherName { get; set; }
        public string ShenasnameSeri { get; set; } //Shenasnameseri
        public int ShenasnameSerial { get; set; } //Shenasnameserial
        public int ShenasnameNo { get; set; }
        public int BirthDate { get; set; }
        public BaseEnumDto Gender { get; set; } //base Enum Dto
        public BaseEnumDto DeathStatus { get; set; }
        public string DeathDate { get; set; }
        public string Zipcode { get; set; }
        public string ZipcodeDesc { get; set; }
        public string ExceptionMessage { get; set; }
        public List<string> Message { get; set; } //type change

        #endregion Properties
    }
}