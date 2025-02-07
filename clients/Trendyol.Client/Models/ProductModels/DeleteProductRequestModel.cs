using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trendyol.Client
{
    public class DeleteProductRequestModel
    {
        [JsonProperty("items")]
        public List<DeleteProduct> Items { get; set; }
        public DeleteProductRequestModel(List<DeleteProduct> items)
        {
            Items = items;
        }

        public class DeleteProduct
        {
            [JsonProperty("barcode")]
            public string Barcode { get; set; }
        }
    }
}
