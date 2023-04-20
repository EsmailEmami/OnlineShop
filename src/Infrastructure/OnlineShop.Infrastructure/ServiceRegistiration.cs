using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Infrastructure.Context;
using OnlineShop.Infrastructure.EFCoreConfig;

namespace OnlineShop.Infrastructure
{
    public static class ServiceRegistiration
    {
        public static IServiceCollection AddServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OnlineShopDbContext>(configuration);

            return services;
        }
    }
}