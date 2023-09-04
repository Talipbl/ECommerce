using Ecommerce.Core.Application.CrossCuttingConcerns.Caching;
using Ecommerce.Core.Application.CrossCuttingConcerns.Caching.InMemory;
using Ecommerce.Core.Application.CrossCuttingConcerns.Logging;
using Ecommerce.Core.Application.CrossCuttingConcerns.Logging.DbLogger;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Core.Application.RegisterModules
{
    public static class CoreRegisterModule
    {
        public static IServiceProvider? ServiceProvider { get; private set; }
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddSingleton<ISystemService, SystemService>();
            services.AddSingleton<ICacheManager, CacheManager>();
            services.AddSingleton<ILogManager, DbLogManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
