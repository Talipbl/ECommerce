using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Trendyol;

public class TrendyolErrorResultDTO
{
    public long Timestamp { get; set; }
    public string Exception { get; set; }
    public List<ErrorModelDTO> Errors { get; set; }
    public class ErrorModelDTO
    {
        public string Key { get; set; }
        public string Message { get; set; }
        public string ErrorCode { get; set; }
        public List<string> Args { get; set; }
    }
}
