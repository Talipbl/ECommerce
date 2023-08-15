using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Service.ExternalServices.APIs.TrendyolClient
{
    public class PriceAndInventoryUpdateRequest
    {
        public List<PriceAndInventory> Items { get; set; }
        
        public class PriceAndInventory
        {
            public string Barcode { get; set; }
            public int Quantity { get; set; }
            public double SalePrice { get; set; }
            public double ListPrice { get; set; }
        }
    }
}
