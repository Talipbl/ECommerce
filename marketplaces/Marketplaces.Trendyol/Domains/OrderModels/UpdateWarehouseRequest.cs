using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplaces.Trendyol
{
    public class UpdateWarehouseRequest
    {
        [JsonProperty("warehouseId")]
        public int WarehouseId { get; set; }
        public UpdateWarehouseRequest(int warehouseId)
        {
            WarehouseId = warehouseId;
        }
    }
}
