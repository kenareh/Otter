using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace Otter.HttpEndPoint.Attributes
{
    public class ApiAuthorizationAttribute : ActionFilterAttribute
    {
        #region Fields

        private readonly string _permission;

        #endregion Fields

        #region Constructor

        public ApiAuthorizationAttribute(string permission)
        {
            _permission = permission;
        }

        #endregion Constructor

        #region Methods

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var user = context.HttpContext.User;
            if (
                user.Identity == null ||
                !user.Identity.IsAuthenticated
            )
            {
                context.Result = new UnauthorizedResult();
            }
            else
            {
                var hasPermissions = await HasPermissions(context, _permission);
                if (!hasPermissions)
                {
                    context.Result = new ObjectResult($"Permission is not allowed.")
                    {
                        StatusCode = (int)HttpStatusCode.Forbidden
                    };
                }
            }
            base.OnActionExecuting(context);

            var resultContext = await next();
            this.OnActionExecuted(resultContext);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }

        private static async Task<bool> HasPermissions(ActionExecutingContext context, string permission)
        {
            var response = false;
            var accessToken = context.HttpContext.Request.Headers["Authorization"].ToString();
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", accessToken);

            HttpRequestMessage request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://access-management.tejaratnoins.ir/api/permissions/" + permission),
                Content = null,
            };
            var result = await client.SendAsync(request);
            if (result.IsSuccessStatusCode)
            {
                response = JsonConvert.DeserializeObject<bool>(result.Content.ReadAsStringAsync().Result);
            }
            return response;
        }

        #endregion Methods
    }
}