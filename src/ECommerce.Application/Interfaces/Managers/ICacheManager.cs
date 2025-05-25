using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Managers
{
    public interface ICacheManager
    {
        bool IsCached(string cacheKey);
        bool AddCache(object value, string cacheKey, int duration = 300);
        void RemoveCache(string cacheKey);
        bool GetCache(string cacheKey, out object result);
    }
}
