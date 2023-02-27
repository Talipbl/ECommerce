using Castle.DynamicProxy;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ECommerceNetCore.Application.MethodInterceptors;
using ECommerceNetCore.Application.Results;
using ECommerceNetCore.Application.ServiceRegistrations;
using ECommerceNetCore.Application.CrossCuttingConcerns;
using Azure.Core.GeoJson;

namespace ECommerceNetCore.Application.Aspects
{
    public class CacheAspect : MethodInterceptor
    {
        public int Duration { get; set; } = 300;
        ICacheManager _memCache;
        int _duration;
        public CacheAspect()
        {
            _duration = Duration;
            _memCache = ApplicationRegisterModule.ServiceProvider.GetService<ICacheManager>();
        }
        public override void Intercept(IInvocation invocation)
        {
            var key = $"{invocation.TargetType.FullName}-{invocation.Method.Name}-{invocation.Method.Attributes}";
            object cacheValue;

            if (_memCache.GetCache(key, out cacheValue))
            {
                invocation.ReturnValue = cacheValue;
                return;
            }
            invocation.Proceed();
            var newObject = invocation.ReturnValue;
            _memCache.AddCache(newObject, key, _duration);
        }
    }
}
