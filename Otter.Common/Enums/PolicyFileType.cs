using System.ComponentModel;

namespace Otter.Common.Enums
{
    public enum PolicyFileType
    {
        [Description("IMEI")]
        Imei = 1,

        [Description("جعبه موبایل")]
        PhoneBox = 2,

        [Description("تست میکروفون")]
        MicrophoneVoice = 3,

        [Description("تصویر دوربین جلو")]
        FrontCamera = 4,

        [Description("تصویر دوربین پشت")]
        BackCamera = 5,
    }
}