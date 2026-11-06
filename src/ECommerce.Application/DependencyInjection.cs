using ECommerce.Trendyol;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Trendyol.Client;

namespace ECommerce.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMappings();
        services.AddMemoryCache();
        services.AddTrendyol(configuration);

        services.AddScoped<ITrendyolProductAdapter, TrendyolProductAdapter>();
        services.AddScoped<ITrendyolOrderAdapter, TrendyolOrderAdapter>();
        services.AddScoped<ITrendyolProductService, TrendyolProductService>();
        services.AddScoped<ITrendyolOrderService, TrendyolOrderService>();

        return services;
    }
}
