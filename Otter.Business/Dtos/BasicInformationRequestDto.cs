using System.ComponentModel.DataAnnotations;

namespace Otter.Business.Dtos
{
    public class BasicInformationRequestDto
    {
        [StringLength(11, ErrorMessage = " طول {0} {1} کاراکتر می باشد.")]
        [Required(ErrorMessage = "ورود {0} الزامی می باشد.", AllowEmptyStrings = false)]
        [RegularExpression(@"^(0)9[01239]\d{8}$", ErrorMessage = "{0} وارد شده معتبر نمی باشد. لطفا به صورت 09XXXXXXXXX  وارد نمیایید.")]
        [Display(Name = "موبایل")]
        public string Mobile { get; set; }

        [Display(Name = "مدل")]
        [Required(ErrorMessage = "ورود {0} الزامی می باشد.", AllowEmptyStrings = false)]
        public long ModelId { get; set; }

        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "ورود {0} الزامی می باشد.", AllowEmptyStrings = false)]
        [Range(10000000, 1000000000, ErrorMessage = "حداقل قیمت موبایل باید {1} و حداکثر قیمت آن میتواند {2} باشد")]
        public long Price { get; set; }

        [Display(Name = "وضعیت گارانتی")]
        [Required(ErrorMessage = "ورود {0} الزامی می باشد.", AllowEmptyStrings = false)]
        public bool GuarantyStatus { get; set; }

        [Display(Name = "کد تخفیف")]
        public string DiscountCode { get; set; }

        [Display(Name = "کد نماینده")]
        public string AgentCode { get; set; }
    }
}