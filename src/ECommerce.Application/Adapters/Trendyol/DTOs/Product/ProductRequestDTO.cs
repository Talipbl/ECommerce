using Newtonsoft.Json;

namespace ECommerce.Trendyol
{
    public partial class ProductRequestDTO
    {
        public string Barcode { get; set; }
        public string Title { get; set; }
        public int ProductMainId { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public int Quantity { get; set; }
        public string StockCode { get; set; }
        public double DimensionalWeight { get; set; }
        public string Description { get; set; }
        public string CurrencyType { get; set; }
        public double ListPrice { get; set; }
        public double SalePrice { get; set; }
        public int VatRate { get; set; }
        public int CargoCompanyId { get; set; }
        public int ShipmentAddressId { get; set; }
        public int ReturningAddressId { get; set; }
        public int DeliveryDuration { get; set; }
        public DeliveryOptionDTO DeliveryOption { get; set; }
        public List<string> Images { get; set; }
        public List<RequestAttributeDTO> Attributes { get; set; }
    }
}
