using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Application;

//bkz: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-6.0
public static class CoreServiceRegistration
{
    public static IServiceProvider ServiceProvider { get; private set; }
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddSingleton<AspectInterceptorSelector>();

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddSingleton<IMemoryCache, MemoryCache>();
        services.AddSingleton<ILogManager, DbLogManager>();
        services.AddSingleton<ICacheManager, CacheManager>();

        ServiceProvider = services.BuildServiceProvider();
        return services;
    }
}
