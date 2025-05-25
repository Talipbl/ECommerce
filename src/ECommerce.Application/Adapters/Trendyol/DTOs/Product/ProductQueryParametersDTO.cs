namespace ECommerce.Trendyol
{
    public class ProductQueryParametersDTO
    {
        public QueryOption Approved { get; set; } = QueryOption.All;
        public string Barcode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Page { get; set; } = 0;
        public DateType DateQueryType { get; set; }
        public int Size { get; set; } = 25;
        public string StockCode { get; set; }
        public QueryOption Archived { get; set; } = QueryOption.All;
        public string ProductMainId { get; set; }
        public QueryOption OnSale { get; set; } = QueryOption.All;
        public QueryOption Rejected { get; set; } = QueryOption.All;
        public QueryOption Blacklisted { get; set; } = QueryOption.All;
        public string[] BrandIds { get; set; }
    }
}
