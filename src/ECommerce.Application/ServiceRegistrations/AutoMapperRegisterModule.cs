using ECommerce.Trendyol;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Application;

public static class AutoMapperRegisterModule
{
    public static IServiceProvider? ServiceProvider { get; private set; }
    public static IServiceCollection AddMappingProfiles(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(TrendyolCrawlerProductDetailDto));
        services.AddAutoMapper(typeof(TrendyolMappingProfile));
        services.AddAutoMapper(typeof(TrendyolWebSearchMappingProfile));

        ServiceProvider = services.BuildServiceProvider();
        return services;
    }
}
