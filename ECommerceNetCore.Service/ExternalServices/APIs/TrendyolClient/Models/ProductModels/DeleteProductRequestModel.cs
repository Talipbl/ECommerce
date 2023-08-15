using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Service.ExternalServices.APIs.TrendyolClient
{
    public class DeleteProductRequestModel
    {
        public List<DeleteProduct> Items { get; set; }

        public class DeleteProduct
        {
            public string Barcode { get; set;}
        }
        
    }
}
