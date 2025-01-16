namespace N11.Client
{
    public class StockItemModel
    {
        public double CurrencyAmount { get; set; }
        public double DisplayPrice { get; set; }
        public double Gtin { get; set; }
        public object Oem { get; set; }
        public object N11CatalogId { get; set; }
        public double OptionPrice { get; set; }
        public string SellerStockCode { get; set; }
        public List<AttributeModel> Attributes { get; set; }
        public double Id { get; set; }
        public int Quantity { get; set; }
        public int Version { get; set; }
    }
}
