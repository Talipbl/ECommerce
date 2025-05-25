using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Trendyol
{
    public class TrendyolBatchRequestResultDTO
    {
        public string BatchRequestId { get; set; }
        public List<Item> Items { get; set; }
        public string Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModification { get; set; }
        public string SourceType { get; set; }
        public int ItemCount { get; set; }

        public class Item
        {
            public List<ProductRequestDTO> RequestItem { get; set; }
            public string Status { get; set; }
            public List<string> FailureReasons { get; set; }
        }
    }
}
