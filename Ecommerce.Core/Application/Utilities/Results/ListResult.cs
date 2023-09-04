using Ecommerce.Core.Application.Utilities.Results.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Application.Utilities.Results
{
    public class ListResult<T> : DataResult<List<T>>, IListResult<T>
    {
        public ListResult(List<T> data, int count, string message) : base(data, true, message)
        {
            Count = count;
        }
        public ListResult(List<T> data, int count) : base(data, true)
        {
            Count = count;
        }
        public int Count { get; }
    }
}
