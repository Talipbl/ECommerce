using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Marketplaces.Hepsiburada
{
    public class BaseHttpClient
    {
        private HttpClient? Client { get; set; }
        private Uri EndPoint { get; set; }
        private string Host { get; set; }
        private string SupplierId { get; set; } = string.Empty;
        private ApiAuthentication? Headers { get; set; }

        public BaseHttpClient(string baseUrl)
        {
            EndPoint = new Uri(baseUrl);
            Host = $"{EndPoint.Host}:{EndPoint.Port}";
        }
        public BaseHttpClient(string baseUri, string supplierId) : this(baseUri)
        {
            SupplierId = supplierId;
        }
        public BaseHttpClient(string baseUri, string supplierId, ApiAuthentication requestHeaders) : this(baseUri, supplierId)
        {
            Headers = requestHeaders;
        }

        public async Task<RootResponseModel<T>> GetAsync<T>(string requestUri)
        {
            RootResponseModel<T> response = new RootResponseModel<T>();
            using (var httpClient = CreateHttpClient())
            {
                var httpResponse = await httpClient.GetAsync(requestUri);
                var result = await httpResponse.Content.ReadAsStringAsync();

                if (httpResponse.IsSuccessStatusCode == false)
                {
                    response.Success = false;
                    response.Message = result;
                }
                else
                {
                    response.Data = JsonConvert.DeserializeObject<List<T>>(result);
                }

                return response;
            }
        }

        public async Task<RootResponseModel<T>> PostAsync<T>(object model, string requestUri)
        {
            RootResponseModel<T> response = new RootResponseModel<T>();
            using (var httpClient = CreateHttpClient())
            {
                var httpContent = (HttpContent)CreateHttpContent(model);
                var httpResponse = await httpClient.PostAsync(requestUri, httpContent);
                var result = await httpResponse.Content.ReadAsStringAsync();

                if (httpResponse.IsSuccessStatusCode == false)
                {
                    response.Success = false;
                    response.Message = result;
                }
                else
                {
                    response.Data = JsonConvert.DeserializeObject<List<T>>(result);
                }

                return response;
            }
        }

        public async Task<RootResponseModel<T>> PutAsync<T>(object model, string requestUri)
        {
            RootResponseModel<T> response = new RootResponseModel<T>();
            using (var httpClient = CreateHttpClient())
            {
                var httpContent = (HttpContent)CreateHttpContent(model);
                var httpResponse = await httpClient.PutAsync(requestUri, httpContent);
                var result = await httpResponse.Content.ReadAsStringAsync();

                if (httpResponse.IsSuccessStatusCode == false)
                {
                    response.Success = false;
                    response.Message = result;
                }
                else
                {
                    response.Data = JsonConvert.DeserializeObject<List<T>>(result);
                }

                return response;
            }
        }

        public async Task<RootResponseModel<T>> DeleteAsync<T>(object model, string requestUri)
        {
            RootResponseModel<T> response = new RootResponseModel<T>();
            using (var httpClient = CreateHttpClient())
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri(requestUri),
                    Content = CreateHttpContent(model)
                };

                var httpResponse = await httpClient.SendAsync(request);
                var result = await httpResponse.Content.ReadAsStringAsync();

                if (httpResponse.IsSuccessStatusCode == false)
                {
                    response.Success = false;
                    response.Message = result;
                }
                else
                {
                    response.Data = JsonConvert.DeserializeObject<List<T>>(result);
                }

                return response;
            }
        }

        private HttpClient CreateHttpClient()
        {
            Client = new HttpClient() { BaseAddress = EndPoint };
            Client.DefaultRequestHeaders.Add("Host", Host);
            Client.DefaultRequestHeaders.Add("User-Agent", $"{SupplierId} - SelfIntegration");

            if (Headers is not null)
            {
                Client.DefaultRequestHeaders.Add("Api-Key", Headers.ApiKey);
                Client.DefaultRequestHeaders.Add("Api-Secret-Key", Headers.ApiSecretKey);
                Client.DefaultRequestHeaders.Add("Authorization", Headers.Authorization);
            }

            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return Client;
        }
        private StringContent CreateHttpContent(object model)
        {
            //JSON nesnesinde default yada null değerlerin işlenemesi için ayarlanıyor.
            JsonSerializerSettings setting = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore
            };

            var jsonFormat = JsonConvert.SerializeObject(model, setting);
            return new StringContent(jsonFormat, Encoding.UTF8, "application/json");
        }
    }
}
