using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Service.ExternalServices.APIs.TrendyolClient
{
    public class UpdatePackageRequest
    {
        public List<Line> Lines { get; set; }
        public ParamsModel Params { get; set; }
        public string Status { get; set; }

        public class Line
        {
            public string LineId { get; set; }
            public int Quantity { get; set; }
        }

        public class ParamsModel
        {
            public string InvoiceNumber { get; set; }
        }
    }

}
