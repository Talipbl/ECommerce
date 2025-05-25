using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Shared.Utilities.Results
{
    public interface IListResult<T> : IDataResult<List<T>>
    {
        public int Count { get; }
    }
}
