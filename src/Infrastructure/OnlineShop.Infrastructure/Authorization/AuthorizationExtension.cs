using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.Application.Core.Authorization;
using OnlineShop.Application.Core.Services.Identity;
using OnlineShop.Application.Services.Identity;
using OnlineShop.Domain.Identity;
using System.Text;

namespace OnlineShop.Infrastructure.Authorization
{
    public static class AuthorizationExtension
    {
        public static IServiceCollection AddJwtIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();

            services.AddScoped<IUser, AspNetUser>();
            services.AddSingleton<IJwtFactory, JwtFactory>();

            // configure identity options
            var options = new IdentityOptions();
            configuration.GetSection(nameof(IdentityOptions)).Bind(options);
            services.Configure<IdentityOptions>(configuration.GetSection("IdentityOptions"));

            // token validation parameters
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = options.ValidateIssuer,
                ValidateAudience = options.ValidateAudience,
                ValidateLifetime = options.ValidateLifeTime,
                ValidateIssuerSigningKey = options.ValidateIssuerSigningKey,
                ValidIssuer = options.Issuer,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Key))
            };

            // events
            var signalRJwtEvent = new JwtBearerEvents
            {
                OnMessageReceived = context =>
                {
                    StringValues accessToken = context.Request.Query["access_token"];

                    // If the request is for our hub...
                    var path = context.HttpContext.Request.Path;
                    if (options.ValidEventPaths == null || string.IsNullOrEmpty(accessToken))
                        return Task.CompletedTask;

                    foreach (var validPath in options.ValidEventPaths)
                    {
                        if (path.StartsWithSegments(validPath))
                        {
                            // Read the token out of the query string
                            context.Token = accessToken;
                        }
                    }
                    return Task.CompletedTask;
                }
            };

            services.AddAuthentication(authenticationOptions =>
            {
                authenticationOptions.DefaultScheme = options.DefaultScheme;
                authenticationOptions.DefaultAuthenticateScheme = options.DefaultScheme;
                authenticationOptions.DefaultChallengeScheme = options.DefaultScheme;
            }).AddJwtBearer(options.DefaultScheme, configureOptions =>
            {
                configureOptions.TokenValidationParameters = tokenValidationParameters;
                configureOptions.Events = signalRJwtEvent;
            });

            services.AddAuthorization();

            services.AddCors(options =>
            {
                options.AddPolicy("EnableCors", builder =>
                {
                    builder.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .WithOrigins("http://localhost:4200")
                        .Build();

                });
            });

            return services;
        }
        public static IApplicationBuilder UseIdentity(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("EnableCors");
            return app;
        }
    }
}
