using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service.Models
{
    public class RootResponseModel<T>
    {
        public object ErrorValueReturn { get; set; }
        public T OkResponse { get; set; }
        public bool IsSuccess { get; set; } = true;
    }
    public class RootResponseModel<T, E>
    {
        public object ErrorValueReturn { get; set; }
        public T OkResponse { get; set; }
        public E AdditionalData { get; set; }
        public bool IsSuccess { get; set; } = true;
    }
}
