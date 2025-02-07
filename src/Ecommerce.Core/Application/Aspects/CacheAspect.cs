using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Core.Application
{
    public class CacheAspect : MethodInterceptor
    {
        public int Duration { get; set; } = 300;
        ICacheManager _memCache;
        int _duration;
        public CacheAspect()
        {
            _duration = Duration;
            _memCache = CoreServiceRegistration.ServiceProvider?.GetRequiredService<ICacheManager>();
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
