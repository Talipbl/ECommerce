using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplaces.Trendyol
{
    public class PriceAndInventoryUpdateRequest
    {
        [JsonProperty("items")]
        public List<PriceAndInventoryModel> Items { get; set; }
        public PriceAndInventoryUpdateRequest(List<PriceAndInventoryModel> items)
        {
            Items = items;
        }
    }
}
