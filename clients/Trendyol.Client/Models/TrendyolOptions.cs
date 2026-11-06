namespace Trendyol.Client
{
    /// <summary>
    /// Trendyol entegrasyon bilgileri. Değerler konfigürasyondaki "Trendyol" bölümünden okunur;
    /// gerçek bilgiler yalnızca user-secrets veya ortam değişkenlerinde tutulmalıdır.
    /// </summary>
    public class TrendyolOptions
    {
        public const string SectionName = "Trendyol";

        public string SellerId { get; set; } = string.Empty;
        public string ApiKey { get; set; } = string.Empty;
        public string ApiSecret { get; set; } = string.Empty;

        public bool IsConfigured =>
            !string.IsNullOrWhiteSpace(SellerId) &&
            !string.IsNullOrWhiteSpace(ApiKey) &&
            !string.IsNullOrWhiteSpace(ApiSecret);

        public ApiAuthentication ToAuthentication() =>
            ApiAuthentication.CreateAuthentication(ApiKey, ApiSecret, SellerId);
    }
}
