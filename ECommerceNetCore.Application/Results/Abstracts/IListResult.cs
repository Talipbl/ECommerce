using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Application.Results
{
    public interface IListResult<T>
    {
        public int Count { get; }
    }
}
