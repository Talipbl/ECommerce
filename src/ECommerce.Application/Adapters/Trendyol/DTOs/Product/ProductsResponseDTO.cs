using Trendyol.Client;

namespace ECommerce.Trendyol
{
    public class ProductsResponseDTO
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public int TotalElements { get; set; }
        public int TotalPages { get; set; }
        public List<ContentDTO> Content { get; set; }

        public class ContentDTO
        {
            public bool Approved { get; set; }
            public bool Archived { get; set; }
            public List<ResponseAttributeDTO> Attributes { get; set; }
            public string Barcode { get; set; }
            public string BatchRequestId { get; set; }
            public string Brand { get; set; }
            public int BrandId { get; set; }
            public string CategoryName { get; set; }
            public object CreateDateTime { get; set; }
            public string Description { get; set; }
            public string Gender { get; set; }
            public bool HasActiveCampaign { get; set; }
            public string Id { get; set; }
            public List<string> Images { get; set; }
            public object LastPriceChangeDate { get; set; }
            public object LastStockChangeDate { get; set; }
            public object LastUpdateDate { get; set; }
            public double ListPrice { get; set; }
            public bool Locked { get; set; }
            public bool OnSale { get; set; }
            public int PimCategoryId { get; set; }
            public string PlatformListingId { get; set; }
            public int ProductCode { get; set; }
            public int ProductContentId { get; set; }
            public string ProductMainId { get; set; }
            public int Quantity { get; set; }
            public double SalePrice { get; set; }
            public string StockCode { get; set; }
            public string StockId { get; set; }
            public string StockUnitType { get; set; }
            public int SupplierId { get; set; }
            public string Title { get; set; }
            public int VatRate { get; set; }
            public int Version { get; set; }
            public bool Rejected { get; set; }
            public List<object> RejectReasonDetails { get; set; }
            public bool Blacklisted { get; set; }
            public int? DeliveryDuration { get; set; }
            public DeliveryOptionDTO DeliveryOptions { get; set; }
        }
    }
}
