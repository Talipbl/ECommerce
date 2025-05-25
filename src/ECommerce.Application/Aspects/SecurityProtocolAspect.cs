using Castle.DynamicProxy;
using System.Net;

namespace ECommerce.Application
{
    public class SecurityProtocolAspect : MethodInterceptor
    {
        public SecurityProtocolType ProtocolType { get; set; } = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;

        protected override void OnBefore(IInvocation invocation)
        {
            ServicePointManager.SecurityProtocol = ProtocolType;
        }
    }
}
