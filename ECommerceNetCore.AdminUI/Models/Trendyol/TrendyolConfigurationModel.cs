namespace ECommerceNetCore.AdminUI.Models.Trendyol
{
    public class TrendyolConfigurationModel
    {
        public string ApiKey { get; set; }
        public string ApiSecretKey { get; set; }
        public string Token { get; set; }
        public int SupplierId { get; set; }
        public CrawlerModel Crawler { get; set; }
        public class CrawlerModel
        {
            public string Suffix { get; set; }
            public double PriceRatio { get; set; }
            public int Quantity { get; set; }
            public int DeliveryDuration { get; set; }
        }
    }
}
