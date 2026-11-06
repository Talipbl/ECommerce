using Newtonsoft.Json;
using System.Reflection;
using System.Web;

namespace N11.Client
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

                if (value != null)
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
    }
}
