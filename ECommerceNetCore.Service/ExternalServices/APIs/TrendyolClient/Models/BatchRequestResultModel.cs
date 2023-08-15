using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Service.ExternalServices.APIs.TrendyolClient.Models
{
    public class BatchRequestResultModel
    {
        public string BatchRequestId { get; set; }
        public List<Item> Items { get; set; }
        public string Status { get; set; }
        public long CreationDate { get; set; }
        public long LastModification { get; set; }
        public string SourceType { get; set; }
        public int ItemCount { get; set; }

        public class Image
        {
            public string Url { get; set; }
        }

        public class Item
        {
            public RequestItem RequestItem { get; set; }
            public string Status { get; set; }
            public List<object> FailureReasons { get; set; }
        }

        public class RequestItem
        {
            public ProductModel Product { get; set; }
        }
    }
}
