using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Application.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }
        public DataResult(T data, bool success) : base(success)
        {
            Data = data;
        }
        public DataResult(bool success, string message) : base(success, message)
        {

        }

        public T Data { get; }
    }

    public class DataResult<T, E> : Result, IDataResult<T, E>
    {
        public DataResult(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }
        public DataResult(T data, bool success) : base(success)
        {
            Data = data;
        }
        public DataResult(E additional, bool success, string message) : base(success, message)
        {
            Additional = additional;
        }
        public DataResult(T data, E additional, bool success) : base(success)
        {
            Data = data;
            Additional = additional;
        }

        public T Data { get; }
        public E Additional { get; }
    }
}
