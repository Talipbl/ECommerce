using Castle.DynamicProxy;
using ECommerceNetCore.Application.MethodInterceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Application.Aspects
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
