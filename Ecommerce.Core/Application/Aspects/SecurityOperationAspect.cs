using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Application
{
    public class SecurityOperationAspect : MethodInterceptor
    {
        public int Level { get; set; } = (int)UserLevels.VeryLow;
        int _level;
        IHttpContextAccessor _accessor;
        public SecurityOperationAspect()
        {
            _level = Level;
            _accessor = CoreRegisterModule.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var crypto = _accessor.HttpContext.Session.GetString("level");
            var userLevel = Convert.ToInt32(AesCrypto.Decrypt(crypto, "Develop"));
            if (userLevel < _level)
            {
                invocation.ReturnValue = new ErrorResult("Bu işlemi yapmak için yetkiniz yok. Lütfen yetkili kişiye başvurun.");
                return;
            }
        }//İşlem loglama yapılacak.
    }
}
