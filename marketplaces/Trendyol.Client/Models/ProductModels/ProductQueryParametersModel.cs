using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trendyol.Client
{
    public class ProductQueryParametersModel
    {
        [JsonProperty("approved")]
        public QueryBooleanOption Approved { get; set; } = QueryBooleanOption.All;

        [JsonProperty("barcode")]
        public string Barcode { get; set; }

        [JsonProperty("startDate")]
        public long? StartDate { get; set; }

        [JsonProperty("endDate")]
        public long? EndDate { get; set; }

        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("dateQueryType")]
        public DateType DateQueryType { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("stockCode")]
        public string StockCode { get; set; }

        [JsonProperty("archived")]
        public QueryBooleanOption Archived { get; set; } = QueryBooleanOption.All;

        [JsonProperty("productMainId")]
        public string ProductMainId { get; set; }

        [JsonProperty("onSale")]
        public QueryBooleanOption OnSale { get; set; } = QueryBooleanOption.All;

        [JsonProperty("rejected")]
        public QueryBooleanOption Rejected { get; set; } = QueryBooleanOption.All;

        [JsonProperty("blacklisted")]
        public QueryBooleanOption Blacklisted { get; set; } = QueryBooleanOption.All;

        [JsonProperty("brandIds")]
        public string[] BrandIds { get; set; }
    }
}
