using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Application;
using OnlineShop.Application.Mapping;
using OnlineShop.Infrastructure.Authorization;
using OnlineShop.Infrastructure.Context;
using OnlineShop.Infrastructure.EFCoreConfig;

namespace OnlineShop.Infrastructure
{
    public static class ServiceRegistiration
    {
        public static IServiceCollection AddServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors();

            services.AddDbContext<OnlineShopDbContext>(configuration);

            //services.AddAutoMapper(typeof(IApplicationService<,,,,,>));
            services.AddSingleton<IMapping, Mapping>();

            services.AddApplicationServicesIoC();

            services.AddJwtIdentity(configuration);

            return services;
        }

        public static IApplicationBuilder AddUseRegistration(this IApplicationBuilder app)
        {
            app.UseStaticFiles();

            app.UseCors(builder => builder.WithOrigins("http://localhost:4200"));
            app.UseIdentity();
            return app;
        }

        private static IServiceCollection AddApplicationServicesIoC(this IServiceCollection services)
        {
            //Services
            var applicationLayer = typeof(ApplicationService<,,,,,>).Assembly;
            var applicationServices = applicationLayer.GetTypes().Where(t => t.Name.EndsWith("Service") && t.BaseType?.IsGenericType == true && t.BaseType.GetGenericTypeDefinition() == typeof(ApplicationService<,,,,,>)).ToArray();

            foreach (var service in applicationServices)
            {
                // Register against all the interfaces implemented
                // by this concrete class
                foreach (var @interface in service.GetInterfaces())
                {
                    services.AddScoped(@interface, service);
                }
            }

            var newApplicationServices = applicationLayer.GetTypes().Where(t => t.Name.EndsWith("Service") && t.BaseType?.IsGenericType == false && t.IsClass);


            foreach (var service in newApplicationServices)
            {
                foreach (var @interface in service.GetInterfaces())
                {
                    services.AddScoped(@interface, service);
                }
            }

            return services;
        }
    }
}