using Newtonsoft.Json;
using System.Text;

namespace Trendyol.Client
{
    public class BaseHttpClient(HttpClient httpClient)
    {
        private static readonly JsonSerializerSettings SerializerSettings = new()
        {
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore
        };

        public Task<RootResponseModel<T>> GetAsync<T>(string requestUri) =>
            SendAsync<T>(new HttpRequestMessage(HttpMethod.Get, requestUri));

        public Task<RootResponseModel<T>> PostAsync<T>(object? model, string requestUri) =>
            SendAsync<T>(new HttpRequestMessage(HttpMethod.Post, requestUri) { Content = CreateContent(model) });

        public Task<RootResponseModel<T>> PutAsync<T>(object? model, string requestUri) =>
            SendAsync<T>(new HttpRequestMessage(HttpMethod.Put, requestUri) { Content = CreateContent(model) });

        public Task<RootResponseModel<T>> DeleteAsync<T>(object? model, string requestUri) =>
            SendAsync<T>(new HttpRequestMessage(HttpMethod.Delete, requestUri) { Content = CreateContent(model) });

        private async Task<RootResponseModel<T>> SendAsync<T>(HttpRequestMessage request)
        {
            using (request)
            using (var httpResponse = await httpClient.SendAsync(request))
            {
                var body = await httpResponse.Content.ReadAsStringAsync();
                var response = new RootResponseModel<T>();

                if (!httpResponse.IsSuccessStatusCode)
                {
                    response.IsSuccess = false;
                    response.ErrorValueReturn = body;
                    return response;
                }

                response.OkResponse = JsonConvert.DeserializeObject<T>(body)!;
                return response;
            }
        }

        private static StringContent CreateContent(object? model) =>
            new(JsonConvert.SerializeObject(model, SerializerSettings), Encoding.UTF8, "application/json");
    }
}
