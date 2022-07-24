using System;
using System.ComponentModel.DataAnnotations;

namespace Otter.Business.Dtos
{
    public class PersonalInfoDto
    {
        [Display(Name = "نام")]
        [Required(ErrorMessage = "ورود {0} الزامی می باشد.", AllowEmptyStrings = false)]
        [MaxLength(100, ErrorMessage = "حداکثر طول {0} {1} کاراکتر می باشد.")]
        public string Firstname { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "ورود {0} الزامی می باشد.", AllowEmptyStrings = false)]
        [MaxLength(100, ErrorMessage = "حداکثر طول {0} {1} کاراکتر می باشد.")]
        public string Lastname { get; set; }

        [Display(Name = "کد ملی")]
        [Required(ErrorMessage = "ورود {0} الزامی می باشد.", AllowEmptyStrings = false)]
        [MaxLength(10, ErrorMessage = "حداکثر طول {0} {1} کاراکتر می باشد.")]
        public string NationalCode { get; set; }

        [Display(Name = "تاریخ تولد")]
        [Required(ErrorMessage = "ورود {0} الزامی می باشد.", AllowEmptyStrings = false)]
        public DateTime BirthDate { get; set; }

        [Display(Name = "آدرس")]
        [Required(ErrorMessage = "ورود {0} الزامی می باشد.", AllowEmptyStrings = false)]
        [MaxLength(500, ErrorMessage = "حداکثر طول {0} {1} کاراکتر می باشد.")]
        public string Address { get; set; }

        [Display(Name = "شهر")]
        [Required(ErrorMessage = "ورود {0} الزامی می باشد.", AllowEmptyStrings = false)]
        public long CityId { get; set; }
    }
}