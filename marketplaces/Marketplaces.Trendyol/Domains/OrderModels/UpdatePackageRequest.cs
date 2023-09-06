using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplaces.Trendyol
{
    public class UpdatePackageRequest
    {
        [JsonProperty("lines")]
        public List<Line> Lines { get; set; }

        [JsonProperty("params")]
        public ParamsModel Params { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        public class Line
        {
            [JsonProperty("lineId")]
            public string LineId { get; set; }

            [JsonProperty("quantity")]
            public int Quantity { get; set; }
        }

        public class ParamsModel
        {
            [JsonProperty("invoiceNumber")]
            public string InvoiceNumber { get; set; }
        }
    }

}
