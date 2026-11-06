using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Trendyol.Client
{
    public static class JsonHelper
    {
        public static string GetJsonPropertyName(PropertyInfo property)
        {
            JsonPropertyAttribute attribute = property.GetCustomAttribute<JsonPropertyAttribute>();
            if (attribute != null)
            {
                return attribute.PropertyName;
            }
            return property.Name;
        }

        public static string BuildQueryString(object obj)
        {
            List<string> queryParts = new List<string>();
            PropertyInfo[] properties = obj.GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                object value = property.GetValue(obj);

                if (value != null && !IsDefaultValue(value))
                {
                    if (value is string[] array && array.Length == 0)
                        continue;

                    string jsonPropertyName = GetJsonPropertyName(property);
                    string encodedValue = HttpUtility.UrlEncode(value.ToString());
                    queryParts.Add($"{jsonPropertyName}={encodedValue}");
                }
            }

            return string.Join("&", queryParts);
        }
        private static bool IsDefaultValue(object value)
        {
            if (value is long longValue)
                return isDefaultDate(longValue);

            if (value is QueryBooleanOption option)
                return option == QueryBooleanOption.All;

            return false;
        }

        private static bool isDefaultDate(long ticks)
        {
            return ticks < 0 || ticks == DateTime.MinValue.Ticks / 10000000;
        }
    }
}
