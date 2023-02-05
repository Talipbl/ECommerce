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
using ECommerceNetCore.Application.Caching;
using ECommerceNetCore.Application.MethodInterceptors;
using ECommerceNetCore.Application.Results;
using ECommerceNetCore.Application.ServiceRegistrations;

namespace ECommerceNetCore.Application.Aspects
{
    public class CacheAspect : MethodInterceptor
    {
        ICacheManager _memCache;
        int _duration;
        public CacheAspect(int duration = 300)
        {
            _duration = duration;
            _memCache = ApplicationRegisterModule.ServiceProvider.GetService<ICacheManager>();
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var key = $"{invocation.TargetType.FullName}-{invocation.Method.Name}-{invocation.Method.Attributes}";
            object cacheValue;

            if (_memCache.GetCache(key, out cacheValue))
            {
                invocation.ReturnValue = new SuccessDataResult<object>(cacheValue);
                IsSuccess = false;
                return;
            }
        }
        protected override void OnSuccess(IInvocation invocation)
        {
            var key = $"{invocation.TargetType.FullName}-{invocation.Method.Name}-{invocation.Method.Attributes}";
            var newObject = invocation.ReturnValue;

            _memCache.AddCache(newObject, key, _duration);
            IsSuccess = true;
        }
    }
}
