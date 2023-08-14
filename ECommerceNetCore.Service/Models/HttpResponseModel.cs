using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Service.Models
{
    public class HttpResponseModel<T>
    {
        public HttpResponseMessage ResponseMessage { get; set; }
        public T Entity { get; set; }
    }
}
