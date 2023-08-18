using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Service.ExternalServices.TrendyolClient
{
    public class PriceAndInventoryUpdateRequest
    {
        [JsonProperty("items")]
        public List<PriceAndInventory> Items { get; set; }

        public class PriceAndInventory
        {
            [JsonProperty("barcode")]
            public string Barcode { get; set; }

            [JsonProperty("quantity")]
            public int Quantity { get; set; }

            [JsonProperty("salePrice")]
            public double SalePrice { get; set; }

            [JsonProperty("listPrice")]
            public double ListPrice { get; set; }
        }
    }
}
