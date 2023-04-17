using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Otter.HttpEndPoint.Attributes;

namespace Otter.HttpEndPoint.Controllers
{
    [Authorize("RequiredMobileInsuranceScopes")]
    [ApiAuthorization("mobile-insurance-admin")]
    [ApiController]
    public class AuthorizedController : ControllerBase
    {
        #region Properties

        // public string UserId => "457ba2cc-9487-4d7f-9f28-bbfaae3cc121"; //todo

        public string UserId => User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";
        public string ClientId => HttpContext.User.Claims.FirstOrDefault(c => c.Type == "client_id")?.Value ?? "";

        public List<string> Audiences => User.Claims.Where(p => p.Type == "aud").Select(p => p.Value).ToList();
        public List<string> Scopes => User.Claims.Where(p => p.Type == "scope").Select(p => p.Value).ToList();

        #endregion Properties
    }
}