using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ECommerceNetCore.Application.MethodInterceptors;
using ECommerceNetCore.Application.CrossCuttingConcerns.Caching;
using ECommerceNetCore.Application.CrossCuttingConcerns.Logging;
using ECommerceNetCore.Application.CrossCuttingConcerns.Logging.DbLogger;

namespace ECommerceNetCore.Application.ServiceRegistrations
{
    //bkz: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-6.0
    public static class ApplicationRegisterModule
    {
        public static IServiceProvider ServiceProvider  { get; private set; }
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddSingleton<ICacheManager, CacheManager>();
            services.AddSingleton<ILogManager, DbLogManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
