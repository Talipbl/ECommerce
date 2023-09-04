using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Application
{
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
    public interface IDataResult<T, E> : IResult
    {
        T Data { get; }
        E Additional { get; }
    }
}
