

using System.Security.Claims;
using APPWEB_PracticePack.Configuration;
using Microsoft.AspNetCore.Authentication;
using APPWEB_PracticePack.Contracts.Adapters;
using Microsoft.AspNetCore.Authentication.Cookies;

using IAuthenticationService = APPWEB_PracticePack.Services.Interfaces.IAuthenticationService;

namespace APPWEB_PracticePack.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ApiSettings _apiSettings;
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthenticationService(ApiSettings apiSettings, IHttpContextAccessor contextAccessor)
        {
            _apiSettings = apiSettings;
            _contextAccessor = contextAccessor;
        }

        public async Task LogInClaims(UserInfoAdapter user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim(_apiSettings.TokenName, user.Token)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTime.UtcNow.AddMinutes(_apiSettings.TokenDuration),
            };

            await _contextAccessor.HttpContext!.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity),
                authProperties
            );
        }
    }
}
