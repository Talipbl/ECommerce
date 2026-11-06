using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace N11.Client
{
    public class BaseHttpClient
    {
        private HttpClient? Client { get; set; }
        private Uri EndPoint { get; set; }
        private string Host { get; set; }
        private ApiAuthentication? Headers { get; set; }

        public BaseHttpClient(string baseUrl)
        {
            EndPoint = new Uri(baseUrl);
            Host = $"{EndPoint.Host}:{EndPoint.Port}";
        }
        public BaseHttpClient(string baseUrl, ApiAuthentication requestHeaders) : this(baseUrl)
        {
            Headers = requestHeaders;
        }

        public async Task<BaseResponse<T>> GetAsync<T>(string requestUri)
        {
            BaseResponse<T> response = new BaseResponse<T>();
            using (var httpClient = CreateHttpClient())
            {
                var httpResponse = await httpClient.GetAsync(requestUri);
                var result = await httpResponse.Content.ReadAsStringAsync();

                if (httpResponse.IsSuccessStatusCode == false)
                {
                    response.ClientResponse.Status = false;
                    response.ClientResponse.ErrorMessage = result;
                }
                else
                {
                    response.ApiResponse = JsonConvert.DeserializeObject<T>(result);
                }

                return response;
            }
        }

        public async Task<BaseResponse<T>> PostAsync<T>(object model, string requestUri)
        {
            BaseResponse<T> response = new BaseResponse<T>();
            using (var httpClient = CreateHttpClient())
            {
                var httpContent = (HttpContent)CreateHttpContent(model);
                var httpResponse = await httpClient.PostAsync(requestUri, httpContent);
                var result = await httpResponse.Content.ReadAsStringAsync();

                if (httpResponse.IsSuccessStatusCode == false)
                {
                    response.ClientResponse.Status = false;
                    response.ClientResponse.ErrorMessage = result;
                }
                else
                {
                    response.ApiResponse = JsonConvert.DeserializeObject<T>(result);
                }

                return response;
            }
        }

        public async Task<BaseResponse<T>> PutAsync<T>(object model, string requestUri)
        {
            BaseResponse<T> response = new BaseResponse<T>();
            using (var httpClient = CreateHttpClient())
            {
                var httpContent = (HttpContent)CreateHttpContent(model);
                var httpResponse = await httpClient.PutAsync(requestUri, httpContent);
                var result = await httpResponse.Content.ReadAsStringAsync();

                if (httpResponse.IsSuccessStatusCode == false)
                {
                    response.ClientResponse.Status = false;
                    response.ClientResponse.ErrorMessage = result;
                }
                else
                {
                    response.ApiResponse = JsonConvert.DeserializeObject<T>(result);
                }

                return response;
            }
        }

        public async Task<BaseResponse<T>> DeleteAsync<T>(object model, string requestUri)
        {
            BaseResponse<T> response = new BaseResponse<T>();
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
                    response.ClientResponse.Status = false;
                    response.ClientResponse.ErrorMessage = result;
                }
                else
                {
                    response.ApiResponse = JsonConvert.DeserializeObject<T>(result);
                }

                return response;
            }
        }
            
        private HttpClient CreateHttpClient()
        {
            Client = new HttpClient() { BaseAddress = EndPoint };
            Client.DefaultRequestHeaders.Add("Host", Host);

            if (Headers is not null)
            {
                Client.DefaultRequestHeaders.Add("appkey", Headers.AppKey);
                Client.DefaultRequestHeaders.Add("appsecret", Headers.AppSecretKey);
            }

            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.Timeout = TimeSpan.FromSeconds(30);
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
