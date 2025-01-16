using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace N11.Client
{
    public class BaseResponse
    {
        public ResultInfo Result { get; set; }

        public class ResultInfo
        {
            public bool Status { get; set; }
            public string ErrorCode { get; set; }
            public string ErrorMessage { get; set; }
        }
    }
}
