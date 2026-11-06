using ECommerce.Trendyol;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Application;

public static class AutoMapperRegisterModule
{
    public static IServiceProvider? ServiceProvider { get; private set; }
    public static IServiceCollection AddMappingProfiles(this IServiceCollection services)
    {
        services.AddAutoMapper(
            typeof(TrendyolTypeConvertProfile),
            typeof(TrendyolBaseResultMappingProfile),
            typeof(TrendyolProductMappingProfile),
            typeof(TrendyolOrderMappingProfile));

        return services;
    }
}
