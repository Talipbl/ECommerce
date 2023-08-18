using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Service.ExternalServices.TrendyolClient
{

    public class ErrorResultModel
    {
        public long Timestamp { get; set; }
        public string Exception { get; set; }
        public List<ErrorModel> Errors { get; set; }


        public class ErrorModel
        {
            public string Key { get; set; }
            public string Message { get; set; }
            public string ErrorCode { get; set; }
            public List<string> Args { get; set; }
        }
    }
}
