using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Template.WebUI.Shared.Common.Interfaces;

namespace Template.WebUI.Server.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public string UserId { get; }
    }
}
