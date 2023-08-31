using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Application
{
    public static class SessionExtension
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            string jsonValue = JsonConvert.SerializeObject(value);
            session.SetString(key, jsonValue);
        }
        public static T GetObject<T>(this ISession session, string key) where T : class, new()
        {
            T response = new T();

            string jsonValue = session.GetString(key);
            if (string.IsNullOrEmpty(jsonValue))
            {
                return response;
            }
            response = JsonConvert.DeserializeObject<T>(jsonValue);
            return response;
        }
    }
}
