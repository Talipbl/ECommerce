using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Application
{
    public class AutofacCoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CacheManager>().As<ICacheManager>().SingleInstance();
            builder.RegisterType<DbLogManager>().As<ILogManager>().SingleInstance();

            var assemblies = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assemblies).AsImplementedInterfaces()
               .EnableInterfaceInterceptors(new ProxyGenerationOptions()
               {
                   Selector = new AspectInterceptorSelector()
               }).SingleInstance();
        }
    }
}
