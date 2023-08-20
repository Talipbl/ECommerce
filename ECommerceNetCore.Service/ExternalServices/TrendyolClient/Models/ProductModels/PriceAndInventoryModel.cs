using Newtonsoft.Json;

namespace ECommerceNetCore.Service.ExternalServices.TrendyolClient
{
    public class PriceAndInventoryModel
    {
        [JsonProperty("barcode")]
        public string Barcode { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("salePrice")]
        public double SalePrice { get; set; }

        [JsonProperty("listPrice")]
        public double ListPrice { get; set; }
    }
}
