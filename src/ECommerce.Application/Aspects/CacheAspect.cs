using Castle.DynamicProxy;
using ECommerce.Application.Managers;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Application
{
    public class CacheAspect : MethodInterceptor
    {
        public int Duration { get; set; } = 300;
        ICacheManager _memCache;
        int _duration;
        public CacheAspect()
        {
            _duration = Duration;
            _memCache = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }
        public override void Intercept(IInvocation invocation)
        {
            var key = $"{invocation.TargetType.FullName}/{invocation.Method.Name}/{string.Concat(invocation.Arguments)}";
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
