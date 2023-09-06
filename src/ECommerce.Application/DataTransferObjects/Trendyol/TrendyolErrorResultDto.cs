using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Trendyol;

public class TrendyolErrorResultDto
{
    public long Timestamp { get; set; }
    public string Exception { get; set; }
    public List<ErrorModelDto> Errors { get; set; }
}
