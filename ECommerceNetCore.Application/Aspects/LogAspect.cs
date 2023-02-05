using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceNetCore.Application.MethodInterceptors;
using ECommerceNetCore.Application.Results;

namespace ECommerceNetCore.Application.Aspects
{
    public class LogAspect : MethodInterceptor
    {
        string _errorMessage;
        protected override void OnException(IInvocation invocation, Exception e)
        {
            _errorMessage = e.Message;
        }
        protected override void OnAfter(IInvocation invocation)
        {
            IsSuccess = true;
            //Veritabanı Log İşlemleri
            invocation.ReturnValue = new ErrorResult(_errorMessage);
        }
    }
}
