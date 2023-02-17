using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceNetCore.Application.MethodInterceptors;
using ECommerceNetCore.Application.Results;
using ECommerceNetCore.Application.CrossCuttingConcerns;
using ECommerceNetCore.Application.ServiceRegistrations;
using Microsoft.Extensions.DependencyInjection;
using ECommerceNetCore.Domain.Entities;

namespace ECommerceNetCore.Application.Aspects
{
    public class LogAspect : MethodInterceptor
    {
        string _errorMessage;
        ILogManager _logManager;
        public LogAspect()
        {
            _logManager = ApplicationRegisterModule.ServiceProvider.GetService<ILogManager>();
        }
        protected override void OnException(IInvocation invocation, Exception e)
        {
            _errorMessage = e.Message;
            IsSuccess = false;
        }
        protected override void OnAfter(IInvocation invocation)
        {
            if (!IsSuccess)
            {
                _logManager.LogError(invocation.Method.Name, _errorMessage);   
                invocation.ReturnValue = new ErrorResult(_errorMessage);
            }
        }
    }
}
