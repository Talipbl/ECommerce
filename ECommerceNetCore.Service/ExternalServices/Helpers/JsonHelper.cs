using ECommerceNetCore.Service.ExternalServices.TrendyolClient;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ECommerceNetCore.Service.ExternalServices
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

                if (value != null && value != "" && value != default && 
                    !(value is int intValue && intValue == 0) && 
                    !(value is QueryBooleanOption option && option == QueryBooleanOption.All ))
                {
                    string jsonPropertyName = GetJsonPropertyName(property);
                    string encodedValue = HttpUtility.UrlEncode(value.ToString());
                    queryParts.Add($"{jsonPropertyName}={encodedValue}");
                }
            }

            return string.Join("&", queryParts);
        }
    }
}
