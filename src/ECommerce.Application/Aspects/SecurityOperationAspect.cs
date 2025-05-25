using Castle.DynamicProxy;
using Ecommerce.Shared.Utilities.Cryptography.AesCrypto;
using Ecommerce.Shared.Utilities.Results;
using ECommerce.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace ECommerce.Application
{
    public class SecurityOperationAspect : MethodInterceptor
    {
        public int Level { get; set; } = (int)UserLevel.VeryLow;
        int _level;
        IHttpContextAccessor _accessor;
        public SecurityOperationAspect()
        {
            _level = Level;
            _accessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
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
