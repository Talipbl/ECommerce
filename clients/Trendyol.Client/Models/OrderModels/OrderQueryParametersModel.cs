using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trendyol.Client
{
    public class OrderQueryParametersModel
    {
        [JsonProperty("startDate")]
        public long? StartDate { get; set; }

        [JsonProperty("endDate")]
        public long? EndDate { get; set; }

        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("supplierId")]
        public long? SupplierId { get; set; }

        [JsonProperty("orderNumber")]
        public string OrderNumber { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("orderByField")]
        public string OrderByField { get; set; }

        [JsonProperty("orderByDirection")]
        public string OrderByDirection { get; set; }

        [JsonProperty("shipmentPackageIds")]
        public long? ShipmentPackageIds { get; set; }
    }
}
