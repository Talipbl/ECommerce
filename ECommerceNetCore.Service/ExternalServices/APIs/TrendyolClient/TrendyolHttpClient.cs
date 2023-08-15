using ECommerceNetCore.Service.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ECommerceNetCore.Service.ExternalServices.APIs.TrendyolClient;
using System.Reflection;

namespace ECommerceNetCore.Service.ExternalServices
{
    public class TrendyolHttpClient
    {
        private HttpClient? Client { get; set; }
        private Uri EndPoint { get; set; }
        private string Host { get; set; }
        private string SupplierId { get; set; } = string.Empty;
        private ApiAuthorizationModel? Headers { get; set; }

        public TrendyolHttpClient(string baseUrl)
        {
            EndPoint = new Uri(baseUrl);
            Host = $"{EndPoint.Host}:{EndPoint.Port}";
        }
        public TrendyolHttpClient(string baseUri, string supplierId) : this(baseUri)
        {
            SupplierId = supplierId;
        }
        public TrendyolHttpClient(string baseUri, string supplierId, ApiAuthorizationModel requestHeaders) : this(baseUri, supplierId)
        {
            Headers = requestHeaders;
        }

        public async Task<HttpResponseModel<T>> GetAsync<T>(string requestUri)
        {
            using (var httpClient = CreateHttpClient())
            {
                HttpResponseModel<T> response = new HttpResponseModel<T>
                {
                    ResponseMessage = await httpClient.GetAsync(requestUri)
                };

                var result = await response.ResponseMessage.Content.ReadAsStringAsync();
                T value = JsonConvert.DeserializeObject<T>(result);
                response.Entity = value;
                return response;
            }
        }

        public async Task<HttpResponseModel<T>> PostAsync<T>(object model, string requestUri)
        {
            using (var httpClient = CreateHttpClient())
            {
                var httpContent = (HttpContent)CreateHttpContent(model);

                HttpResponseModel<T> response = new HttpResponseModel<T>
                {
                    ResponseMessage = await httpClient.PostAsync(requestUri, httpContent)
                };

                var result = await response.ResponseMessage.Content.ReadAsStringAsync();
                T value = JsonConvert.DeserializeObject<T>(result);
                response.Entity = value;
                return response;
            }
        }

        public async Task<HttpResponseModel<T>> PutAsync<T>(object model, string requestUri)
        {
            using (var httpClient = CreateHttpClient())
            {
                var httpContent = (HttpContent)CreateHttpContent(model);

                HttpResponseModel<T> response = new HttpResponseModel<T>
                {
                    ResponseMessage = await httpClient.PutAsync(requestUri, httpContent)
                };

                var result = await response.ResponseMessage.Content.ReadAsStringAsync();
                T value = JsonConvert.DeserializeObject<T>(result);
                response.Entity = value;
                return response;
            }
        }

        public async Task<HttpResponseModel<T>> DeleteAsync<T>(object model, string requestUri)
        {
            using (var httpClient = CreateHttpClient())
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri(requestUri),
                    Content = (HttpContent)CreateHttpContent(model)
                };

                HttpResponseModel<T> response = new HttpResponseModel<T>
                {
                    ResponseMessage = await httpClient.SendAsync(request)
                };

                var result = await response.ResponseMessage.Content.ReadAsStringAsync();
                T value = JsonConvert.DeserializeObject<T>(result);
                response.Entity = value;
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
        private object CreateHttpContent(object model)
        {
            var jsonFormat = JsonConvert.SerializeObject(model);
            return new StringContent(jsonFormat, Encoding.UTF8, "application/json");
        }
    }
}
