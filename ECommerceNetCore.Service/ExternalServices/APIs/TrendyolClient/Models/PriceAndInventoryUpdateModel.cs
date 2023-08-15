using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Service.ExternalServices.APIs.TrendyolClient
{
    public class PriceAndInventoryUpdateModel
    {
        public string Barcode { get; set; }
        public int Quantity { get; set; }
        public double SalePrice { get; set; }
        public double ListPrice { get; set; }
    }
}
