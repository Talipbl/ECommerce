using Newtonsoft.Json;

namespace N11.Client
{
    public class Product
    {
        [JsonProperty("n11ProductId")]
        public int N11ProductId { get; set; }

        [JsonProperty("sellerId")]
        public int SellerId { get; set; }

        [JsonProperty("sellerNickname")]
        public string SellerNickname { get; set; }

        [JsonProperty("stockCode")]
        public string StockCode { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }

        [JsonProperty("productMainId")]
        public string ProductMainId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("saleStatus")]
        public string SaleStatus { get; set; }

        [JsonProperty("preparingDay")]
        public int PreparingDay { get; set; }

        [JsonProperty("shipmentTemplate")]
        public string ShipmentTemplate { get; set; }

        [JsonProperty("maxPurchaseQuantity")]
        public int MaxPurchaseQuantity { get; set; }

        [JsonProperty("customTextOptions")]
        public List<object> CustomTextOptions { get; set; }

        [JsonProperty("catalogId")]
        public int CatalogId { get; set; }

        [JsonProperty("barcode")]
        public object Barcode { get; set; }

        [JsonProperty("groupId")]
        public int GroupId { get; set; }

        [JsonProperty("currencyType")]
        public string CurrencyType { get; set; }

        [JsonProperty("salePrice")]
        public double SalePrice { get; set; }

        [JsonProperty("listPrice")]
        public int ListPrice { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("attributes")]
        public List<Attribute> Attributes { get; set; }

        [JsonProperty("imageUrls")]
        public List<string> ImageUrls { get; set; }

        [JsonProperty("vatRate")]
        public int VatRate { get; set; }

        [JsonProperty("commissionRate")]
        public int CommissionRate { get; set; }
    }

    public class ProductBasic
    {
        public long Id { get; set; }
        public string ProductSellerCode { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public decimal DisplayPrice { get; set; }
        public bool IsDomestic { get; set; }
        public string SaleStatus { get; set; }
        public string ApprovalStatus { get; set; }
        public ProductSku StockItems { get; set; }
        public decimal OldPrice { get; set; }
        public decimal CurrencyAmount { get; set; }
        public string CurrencyType { get; set; }
        public string ProductStatusDetail { get; set; }
    }
}
