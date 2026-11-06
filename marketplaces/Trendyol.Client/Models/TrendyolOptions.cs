using System.Text;

namespace Trendyol.Client
{
    /// <summary>
    /// Trendyol entegrasyon ayarları ("Trendyol" konfigürasyon bölümü).
    /// Gerçek bilgiler yalnızca user-secrets veya ortam değişkenlerinde tutulur.
    /// </summary>
    public class TrendyolOptions
    {
        public const string SectionName = "Trendyol";

        public string BaseUrl { get; set; } = "https://api.trendyol.com";
        public string SellerId { get; set; } = string.Empty;
        public string ApiKey { get; set; } = string.Empty;
        public string ApiSecret { get; set; } = string.Empty;
        public int TimeoutSeconds { get; set; } = 30;

        public bool IsConfigured =>
            !string.IsNullOrWhiteSpace(SellerId) &&
            !string.IsNullOrWhiteSpace(ApiKey) &&
            !string.IsNullOrWhiteSpace(ApiSecret);

        public string UserAgent => $"{SellerId} - SelfIntegration";

        public string BasicAuthParameter => Convert.ToBase64String(Encoding.ASCII.GetBytes($"{ApiKey}:{ApiSecret}"));
    }
}
