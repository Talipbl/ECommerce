using Ecommerce.Core.Application.CrossCuttingConcerns.Caching;
using Ecommerce.Core.Application.Interceptors;

namespace Ecommerce.Core.Application.Aspects
{
    public class CacheAspect : MethodInterceptor
    {
        public int Duration { get; set; } = 300;
        ICacheManager _memCache;
        int _duration;
        public CacheAspect()
        {
            _duration = Duration;
            _memCache = CoreRegisterModule.ServiceProvider.GetService<ICacheManager>();
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
