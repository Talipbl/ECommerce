using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Core.Application
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptor : Attribute, IInterceptor
    {
        protected bool IsSuccess;
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }

        public virtual void Intercept(IInvocation invocation)
        {
            IsSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                var logManager = CoreServiceRegistration.ServiceProvider.GetService<ILogManager>();
                logManager.LogError(invocation.Method.Name, $"{e.Message} -- {e.InnerException?.Message} -- {e.StackTrace}");
                invocation.ReturnValue = new ErrorResult(e.Message);
                IsSuccess = false;
                OnException(invocation, e);
            }
            finally
            {
                if (IsSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }
    }
}
