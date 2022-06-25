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
        MicrophoneVoice = 3
    }
}