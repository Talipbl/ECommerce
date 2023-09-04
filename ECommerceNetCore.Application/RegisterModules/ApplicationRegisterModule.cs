using Ecommerce.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Application
{
    //bkz: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-6.0
    public static class ApplicationRegisterModule
    {
        public static IServiceProvider? ServiceProvider { get; private set; }
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
