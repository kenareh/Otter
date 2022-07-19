using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Otter.HttpEndPoint.Controllers
{
    [Authorize]
    [ApiController]
    public class AuthorizedController : ControllerBase
    {
        #region Properties

        public string UserId => User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";
        public string ClientId => HttpContext.User.Claims.FirstOrDefault(c => c.Type == "client_id")?.Value ?? "";
        public List<string> Audiences => User.Claims.Where(p => p.Type == "aud").Select(p => p.Value).ToList();
        public List<string> Scopes => User.Claims.Where(p => p.Type == "scope").Select(p => p.Value).ToList();

        #endregion Properties
    }
}