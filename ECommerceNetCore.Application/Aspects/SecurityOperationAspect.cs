using Castle.DynamicProxy;
using ECommerceNetCore.Application.CrossCuttingConcerns;
using ECommerceNetCore.Application.MethodInterceptors;
using ECommerceNetCore.Application.Results;
using ECommerceNetCore.Application.ServiceRegistrations;
using ECommerceNetCore.Domain.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Application.Aspects
{
    public class SecurityOperationAspect : MethodInterceptor
    {
        int _level;
        IHttpContextAccessor _accessor;
        public SecurityOperationAspect(int Level = (int)UserLevels.VeryLow)
        {
            _level = Level;
            _accessor = ApplicationRegisterModule.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var userLevel = _accessor.HttpContext.Session.GetInt32("UserLevel");
            if (userLevel < _level)
            {
                invocation.ReturnValue = new ErrorResult("Bu işlemi yapmak için yetkiniz yok. Lütfen yetkili kişiye başvurun.");
                return;
            }
        }//İşlem loglama yapılacak.
    }
}
