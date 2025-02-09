using ECommerce.Trendyol;

namespace Ecommerce.Trendyol
{
    public class CreateProductRequestVM
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
        public double ListPrice { get; set; }
        public double SalePrice { get; set; }
        public int VatRate { get; set; }
        public int DeliveryDuration { get; set; }
        public string FastDeliveryType { get; set; }
        public List<string> Images { get; set; }
        public List<TrendyolRequestAttributeDTO> Attributes { get; set; }
    }
}
