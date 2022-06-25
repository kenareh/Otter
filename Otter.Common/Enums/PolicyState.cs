using System.ComponentModel;

namespace Otter.Common.Enums
{
    public enum PolicyState
    {
        [Description("ثبت اولیه")]
        BasicRegistered,

        [Description("موبایل تایید شده")]
        MobileConfirmed
    }
}