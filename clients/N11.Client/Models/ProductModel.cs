using N11.Client.Services.ProductService;

namespace N11.Client
{
    public class ProductModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public decimal DisplayPrice { get; set; }
        public decimal Price { get; set; }
        public string ProductSellerCode { get; set; }
        public string Description { get; set; }
        public CategoryModel Category { get; set; }
        public SpecialProductInfoModel[] SpecialProductInfoList { get; set; }
        public string PreparingDay { get; set; }
        public string ProductCondition {  get; set; }
        public string ExpirationDate { get; set; }
        public ImageModel[] Images { get; set; }
        public SkuListModel StockItems { get; set; }
        public ProductDiscountModel Discount { get; set; }
        public string ShipmentTemplate { get; set; }
        public string GroupAttribute { get; set; }
        public string GroupItemCode { get; set; }
        public string ItemName { get; set; }
        public AttributeModel[] Attributes { get; set; }
        public string ApprovalStatus { get; set; }
        public string SaleStatus { get; set; }
        public decimal CurrencyAmount { get; set; }
        public string CurrencyType { get; set; }
        public UnitInfoModel UnitInfo { get; set; }
        public string MaxPurchaseQuantity { get; set; }
        public string ProductStatusDetail { get; set; }
        public string SellerNote { get; set; }
    }

    public class ProductBasicModel
    {
        public long Id { get; set; }
        public string ProductSellerCode { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public decimal DisplayPrice { get; set; }
        public bool IsDomestic { get; set; }
        public string SaleStatus { get; set; }
        public string ApprovalStatus { get; set; }
        public ProductSkuModel StockItems { get; set; }
        public decimal OldPrice { get; set; }
        public decimal CurrencyAmount { get; set; }
        public string CurrencyType { get; set; }
        public string ProductStatusDetail { get; set; }
    }
}
