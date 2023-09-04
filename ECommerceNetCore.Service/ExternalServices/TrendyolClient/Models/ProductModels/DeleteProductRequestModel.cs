using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service.ExternalServices.TrendyolClient.Models.ProductModels
{
    public class DeleteProductRequestModel
    {
        [JsonProperty("items")]
        public List<DeleteProduct> Items { get; set; }

        public class DeleteProduct
        {
            [JsonProperty("barcode")]
            public string Barcode { get; set; }
        }
    }
}
