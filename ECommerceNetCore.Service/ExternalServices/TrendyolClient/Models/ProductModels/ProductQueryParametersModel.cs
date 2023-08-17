using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Service.ExternalServices.TrendyolClient
{
    public class ProductQueryParametersModel
    {
        [JsonProperty("approved")]
        public bool Approved { get; set; }

        [JsonProperty("barcode")]
        public string Barcode { get; set; }

        [JsonProperty("startDate")]
        public long? StartDate { get; set; }

        [JsonProperty("endDate")]
        public long? EndDate { get; set; }

        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("dateQueryType")]
        public string DateQueryType { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("supplierId")]
        public long? SupplierId { get; set; }

        [JsonProperty("stockCode")]
        public string StockCode { get; set; }

        [JsonProperty("archived")]
        public bool Archived { get; set; }

        [JsonProperty("productMainId")]
        public string ProductMainId { get; set; }

        [JsonProperty("onSale")]
        public bool OnSale { get; set; }

        [JsonProperty("rejected")]
        public bool Rejected { get; set; }

        [JsonProperty("blacklisted")]
        public bool Blacklisted { get; set; }

        [JsonProperty("brandIds")]
        public string[] BrandIds { get; set; }
    }
}
