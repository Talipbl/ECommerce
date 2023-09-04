using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.ServiceRegistrations;
using Microsoft.Extensions.DependencyInjection;
using ECommerce.Domain.Entities;
using ECommerce.Application.Utilities;
using Ecommerce.Core.Application.CrossCuttingConcerns.Logging;
using Ecommerce.Core.Application.Interceptors;

namespace Ecommerce.Core.Application.Aspects
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
            _errorMessage = $"{e.Message} -- {e.InnerException ?? new Exception()} -- {e.StackTrace}";
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
