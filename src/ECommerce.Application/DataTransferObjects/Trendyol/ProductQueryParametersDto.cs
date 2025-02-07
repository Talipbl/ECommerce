using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Client;

namespace ECommerce.Trendyol
{
    public class ProductQueryParametersDto
    {
        public QueryBooleanOption Approved { get; set; } = QueryBooleanOption.All;
        public string Barcode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Page { get; set; } = 0;
        public DateType DateQueryType { get; set; }
        public int Size { get; set; } = 25;
        public string StockCode { get; set; }
        public QueryBooleanOption Archived { get; set; } = QueryBooleanOption.All;
        public string ProductMainId { get; set; }
        public QueryBooleanOption OnSale { get; set; } = QueryBooleanOption.All;
        public QueryBooleanOption Rejected { get; set; } = QueryBooleanOption.All;
        public QueryBooleanOption Blacklisted { get; set; } = QueryBooleanOption.All;
        public string[] BrandIds { get; set; }
    }
}
