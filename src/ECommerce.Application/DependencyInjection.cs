using ECommerce.Application.Catalog;
using ECommerce.Application.Marketplaces.Trendyol;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Trendyol.Client;

namespace ECommerce.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMappings();
        services.AddMemoryCache();
        services.TryAddSingleton(TimeProvider.System);
        services.AddValidatorsFromAssemblyContaining<CreateTrendyolProductsRequestValidator>();

        services.AddScoped<ICategoryAdminService, CategoryAdminService>();
        services.AddScoped<IBrandAdminService, BrandAdminService>();
        services.AddScoped<ProductAdminService>();
        services.AddScoped<IProductAdminService>(sp => sp.GetRequiredService<ProductAdminService>());
        services.AddScoped<IProductImageService, ProductImageService>();
        services.AddScoped<IStorefrontService, StorefrontService>();

        services.AddTrendyol(configuration);
        services.AddScoped<ITrendyolCatalogService, TrendyolCatalogService>();
        services.AddScoped<TrendyolBatchTracker>();
        services.AddScoped<ITrendyolProductService, TrendyolProductService>();
        services.AddScoped<ITrendyolBatchService, TrendyolBatchService>();
        services.AddScoped<ITrendyolOrderService, TrendyolOrderService>();

        return services;
    }
}
