namespace N11.Client
{
    public class StockItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string CurrencyType { get; set; }
        public string ProductMainId { get; set; }
        public int PreparingDay { get; set; }
        public string ShipmentTemplate { get; set; }
        public int MaxPurchaseQuantity { get; set; }
        public string StockCode { get; set; }
        public object CatalogId { get; set; }
        public long Barcode { get; set; }
        public int Quantity { get; set; }
        public List<Image> Images { get; set; }
        public List<Attribute> Attributes { get; set; }
        public int SalePrice { get; set; }
        public int ListPrice { get; set; }
        public int VatRate { get; set; }
        public string Status { get; set; }
        public bool DeleteProductMainId { get; set; }
        public bool DeleteMaxPurchaseQuantity { get; set; }
    }
}
