using System.ComponentModel;

namespace Otter.Common.Enums
{
    public enum PolicyState
    {
        [Description("ثبت اولیه")]
        BasicRegistered = 0,

        [Description("موبایل تایید شده")]
        MobileConfirmed = 1,

        [Description("در انتظار پرداخت")]
        WaitForPayment = 2,

        [Description("پرداخت شده")]
        Paid = 3,
    }
}