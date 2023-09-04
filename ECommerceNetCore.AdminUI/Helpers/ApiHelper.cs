using ECommerce.AdminUI.Models;
using ECommerce.Application.Aspects;
using ECommerce.Domain.Common.Constants;
using ECommerce.Domain.Entities;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;

namespace ECommerce.AdminUI.Helpers
{
    public class ApiHelper
    {
        public static HttpClient CreateApiClient()
        {
            HttpClient ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return ApiClient;
        }

        [LogAspect]
        public static async Task<JsonModel> PostMultipartFormApiResponse(string url, byte[] entity, string fileName)
        {
            HttpClient ApiClient = CreateApiClient();
            HttpResponseMessage message = new HttpResponseMessage();
            using (var memoryStream = new MemoryStream(entity))
            {
                using (var streamContent = new StreamContent(memoryStream))
                {
                    using (var fileContent = new ByteArrayContent(await streamContent.ReadAsByteArrayAsync()))
                    {
                        fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                        var content = new MultipartFormDataContent();
                        content.Add(fileContent, "file", fileName);

                        message = await ApiClient.PostAsync(url, content);
                    }
                }
            }
            var stringResult = await message.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<JsonModel>(stringResult);
        }

        [LogAspect]
        public static async Task<JsonModel> GetApiResponse(string url)
        {
            using (var client = CreateApiClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string stringResult = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<JsonModel>(stringResult);
                }
            }
            return new JsonModel(false, ValidationConst.ConnecitonError);
        }
    }
}
