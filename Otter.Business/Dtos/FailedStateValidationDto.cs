using System.ComponentModel.DataAnnotations;

namespace Otter.Business.Dtos
{
    public class FailedStateValidationDto
    {
        public bool ImeiFileState { get; set; }
        public bool MicrophoneTestState { get; set; }
        public bool PhoneFileBoxState { get; set; }
        public bool CameraFileState { get; set; }

        [Display(Name = "توضیحات")]
        [MaxLength(500, ErrorMessage = "حداکثر طول {0} {1} کاراکتر می باشد.")]
        public string Description { get; set; }
    }
}