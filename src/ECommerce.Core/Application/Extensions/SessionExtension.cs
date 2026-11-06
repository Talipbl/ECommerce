using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Application
{
    public static class SessionExtension
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            string jsonString = JsonConvert.SerializeObject(value);
            byte[] byteArray = Encoding.UTF8.GetBytes(jsonString);
            session.Set(key, byteArray);
        }
        public static T GetObject<T>(this ISession session, string key) where T : class, new()
        {
            T response = new T();
            byte[] byteArray;
            bool isSuccess = session.TryGetValue(key, out byteArray);

            if (isSuccess)
            {
                return response;
            }

            string jsonString = Encoding.UTF8.GetString(byteArray);
            response = JsonConvert.DeserializeObject<T>(jsonString);
            return response;
        }
        public static string GetString(this ISession session, string key)
        {
            byte[] byteArray;
            bool isSuccess = session.TryGetValue(key, out byteArray);
            string jsonString = string.Empty;

            if (isSuccess)
            {
                return jsonString;
            }

            jsonString = Encoding.UTF8.GetString(byteArray);
            return jsonString;
        }
    }
}
