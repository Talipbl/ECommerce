using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Service.ExternalServices.TrendyolClient
{
    public partial class ProductRequestModel
    {
        [JsonProperty("items")]
        public List<ProductModel> Items { get; set; }
        public ProductRequestModel(List<ProductModel> items)
        {
            Items = items;
        }
    }
}
