using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N11.Client.Extensions
{
    public static class DynamicExtensions
    {
        public static dynamic GetPropertyOrDefault(this object obj, string propertyName)
        {
            var property = obj.GetType().GetProperty(propertyName);
            return property != null ? property.GetValue(obj) : null;
        }
    }
}
