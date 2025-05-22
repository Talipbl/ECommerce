namespace ECommerce.Trendyol
{
    public class PriceAndInventoryUpdateRequestDTO
    {
        public string Barcode { get; set; }
        public int Quantity { get; set; }
        public double SalePrice { get; set; }
        public double ListPrice { get; set; }
    }
}
