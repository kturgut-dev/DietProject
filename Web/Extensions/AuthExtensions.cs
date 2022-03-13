using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Web.Extensions
{
    public static class AuthExtensions
    {
        public static IServiceCollection AddAuth(this IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(opts =>
                {
                    opts.Cookie.Name = $"admin.auth";
                    opts.AccessDeniedPath = "/Home/AccessDenied";
                    opts.LoginPath = "/Login";
                    opts.LogoutPath = "/Logout";
                    opts.SlidingExpiration = true;
                    opts.ExpireTimeSpan = TimeSpan.FromHours(4);
                });

            //services.AddSession(options =>
            //{
            //    options.Cookie.Name = $"admin.session.auth".SHA256ToString();
            //    options.IdleTimeout = TimeSpan.FromHours(4);
            //    options.Cookie.IsEssential = true;
            //});

            return services;
        }

        public static IApplicationBuilder UseAuth(this IApplicationBuilder app)
        {
            app.UseAuthentication();

            app.UseAuthorization();

            return app;
        }
    }
}
