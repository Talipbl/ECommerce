using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;

namespace Trendyol.Client
{
    public static class TrendyolServiceCollectionExtensions
    {
        public static IServiceCollection AddTrendyol(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions<TrendyolOptions>()
                .Bind(configuration.GetSection(TrendyolOptions.SectionName))
                .Validate(o => o.IsConfigured, "Trendyol ayarları eksik. SellerId, ApiKey ve ApiSecret değerlerini user-secrets veya ortam değişkenleri ile tanımlayın.")
                .ValidateOnStart();

            services.AddHttpClient<TrendyolProductClient>(ConfigureClient).AddStandardResilienceHandler();
            services.AddHttpClient<TrendyolOrderClient>(ConfigureClient).AddStandardResilienceHandler();

            return services;
        }

        private static void ConfigureClient(IServiceProvider provider, HttpClient client)
        {
            var options = provider.GetRequiredService<IOptions<TrendyolOptions>>().Value;

            client.BaseAddress = new Uri(options.BaseUrl);
            client.Timeout = TimeSpan.FromSeconds(options.TimeoutSeconds);
            client.DefaultRequestHeaders.UserAgent.ParseAdd(options.UserAgent);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", options.BasicAuthParameter);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
