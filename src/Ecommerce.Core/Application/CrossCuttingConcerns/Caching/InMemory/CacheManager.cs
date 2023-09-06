using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Core.Application
{
    public class CacheManager : ICacheManager
    {
        IMemoryCache _memoryCache;
        public CacheManager()
        {
            _memoryCache = CoreServiceRegistration.ServiceProvider.GetService<IMemoryCache>();
        }
        public bool AddCache(object value, string cacheKey, int duration = 300)
        {
            _memoryCache.Set(cacheKey, value, new MemoryCacheEntryOptions()
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(duration),
                Priority = CacheItemPriority.Normal
            });

            return IsCached(cacheKey);
        }

        public bool GetCache(string cacheKey, out object result)
        {
            return _memoryCache.TryGetValue(cacheKey, out result);
        }

        public bool IsCached(string cacheKey)
        {
            return _memoryCache.TryGetValue(cacheKey, out var result);
        }

        public void RemoveCache(string cacheKey)
        {
            _memoryCache.Remove(cacheKey);
        }
    }
}
