using System.Reflection;
using APPWEB_PracticePack.Services;
using APPWEB_PracticePack.Services.Interfaces;

using CookieAuthenticationDefaults = Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults;
using CookieAuthenticationEvents = Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents;

namespace APPWEB_PracticePack.Configuration
{
    public static class IoC
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            int.TryParse(configuration["ApiSettings:TokenExpiration"], out int expiration);

            var apiSettings = new ApiSettings()
            {
                BaseUrl = configuration["ApiSettings:BaseUrl"] ?? "",
                TokenDuration = expiration,
            };

            services.AddSingleton(apiSettings);
            services.AddHttpContextAccessor();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/User/Login";
                    options.AccessDeniedPath = "/User/AccessDenied";
                    options.Cookie.HttpOnly = true;
                    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(expiration);
                    options.SlidingExpiration = true;

                    options.Events = new CookieAuthenticationEvents
                    {
                        OnRedirectToLogin = context =>
                        {
                            if (context.Request.Path.StartsWithSegments("/api"))
                            {
                                context.Response.StatusCode = 401;
                            }
                            else
                            {
                                var redirectUri = context.RedirectUri;
                                redirectUri = redirectUri.Replace("/User/Login", "/User/Login?expired=true");
                                context.Response.Redirect(redirectUri);
                            }
                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddAuthorization();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();

            return services;
        }
    }
}
