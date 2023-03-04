using System.ComponentModel;

namespace Otter.Common.Enums
{
    public enum ApiResultStatusCode
    {
        [Description("عملیات با موفقیت انجام شد")]
        Success = 200,

        [Description("پارامتر های ارسالی معتبر نیستند")]
        BadRequest = 400,

        [Description("خطای احراز هویت")]
        UnAuthorized = 401,

        [Description("خطای دسترسی")]
        Forbidden = 403,

        [Description("منبع اطلاعاتی موردنظر یافت نشد")]
        NotFound = 404,

        [Description("متد موردنظر مجاز نمی باشد")]
        MethodNotAllowed = 405,

        [Description("محتوایی مطابق معیار ارائه شده، یافت نشد")]
        NotAcceptable = 406,

        [Description("درحال حاضر سرور پاسخگو نیست")]
        RequestTimeout = 408,

        [Description("خطایی در سرور رخ داده است")]
        ServerError = 500,

        [Description("خطایی در پردازش رخ داد")]
        LogicError = 1000,
    }
}