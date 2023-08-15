using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Service.ExternalServices.APIs.TrendyolClient
{
    public class UpdateWarehouseRequest
    {
        public int WarehouseId { get; set; }
        public UpdateWarehouseRequest(int warehouseId)
        {
            WarehouseId = warehouseId;
        }
    }
}
