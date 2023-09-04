using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Core.Application
{
    public class LogAspect : MethodInterceptor
    {
        string _errorMessage;
        ILogManager _logManager;
        public LogAspect()
        {
            _logManager = CoreRegisterModule.ServiceProvider.GetService<ILogManager>();
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
