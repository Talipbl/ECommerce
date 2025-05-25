using ECommerce.Application.Managers;
using ECommerce.Infrastructure.CrossCuttingConcerns;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Infrastructure.RegisterModules;

//bkz: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-6.0
public static class InfrastructureServiceRegistration
{
    public static IServiceProvider ServiceProvider { get; private set; }
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddSingleton<IMemoryCache, MemoryCache>();
        services.AddSingleton<ILogManager, DbLogManager>();
        services.AddSingleton<ICacheManager, CacheManager>();

        ServiceProvider = services.BuildServiceProvider();
        return services;
    }
}
