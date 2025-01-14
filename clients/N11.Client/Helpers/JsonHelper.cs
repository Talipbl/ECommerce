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
    }
}
