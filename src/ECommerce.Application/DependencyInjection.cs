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

        return services;
    }
}
