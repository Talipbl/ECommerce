using Newtonsoft.Json;

namespace ECommerceNetCore.Service.ExternalServices.TrendyolClient
{
    public class ProductModel
    {
        [JsonProperty("barcode")]
        public string Barcode { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("productMainId")]
        public string ProductMainId { get; set; }

        [JsonProperty("brandId")]
        public int BrandId { get; set; }

        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("stockCode")]
        public string StockCode { get; set; }

        [JsonProperty("dimensionalWeight")]
        public int DimensionalWeight { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("currencyType")]
        public string CurrencyType { get; set; }

        [JsonProperty("listPrice")]
        public double ListPrice { get; set; }

        [JsonProperty("salePrice")]
        public double SalePrice { get; set; }

        [JsonProperty("vatRate")]
        public int VatRate { get; set; }

        [JsonProperty("cargoCompanyId")]
        public int CargoCompanyId { get; set; }

        [JsonProperty("shipmentAddressId")]
        public int ShipmentAddressId { get; set; }

        [JsonProperty("returningAddressId")]
        public int ReturningAddressId { get; set; }

        [JsonProperty("deliveryDuration")]
        public int DeliveryDuration { get; set; }

        [JsonProperty("deliveryOption")]
        public RequestDeliveryOptionModel DeliveryOption { get; set; }

        [JsonProperty("images")]
        public List<RequestImage> Images { get; set; }

        [JsonProperty("attributes")]
        public List<RequestAttribute> Attributes { get; set; }

        public class RequestAttribute
        {
            [JsonProperty("attributeId")]
            public int AttributeId { get; set; }

            [JsonProperty("attributeValueId")]
            public int AttributeValueId { get; set; }

            [JsonProperty("customAttributeValue")]
            public string CustomAttributeValue { get; set; }
        }

        public class RequestDeliveryOptionModel
        {
            [JsonProperty("deliveryDuration")]
            public int DeliveryDuration { get; set; }

            [JsonProperty("fastDeliveryType")]
            public string FastDeliveryType { get; set; }
        }

        public class RequestImage
        {
            [JsonProperty("url")]
            public string Url { get; set; }
        }
    }
}
