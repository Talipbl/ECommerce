using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Cors.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceNetCore.Application.MethodInterceptors;
using ECommerceNetCore.Application.CrossCuttingConcerns.Logging;
using ECommerceNetCore.Application.CrossCuttingConcerns.Logging.DbLogger;
using ECommerceNetCore.Application.CrossCuttingConcerns.Caching;

namespace ECommerceNetCore.Persistance.ServiceRegistrations
{
    public class AutofacPersistanceModule : Module
    {
        //Autofac
        protected override void Load(ContainerBuilder builder)
        {
            LoadRepositories(builder);
            LoadServices(builder);

            builder.RegisterType<CacheManager>().As<ICacheManager>().SingleInstance();
            builder.RegisterType<DbLogManager>().As<ILogManager>().SingleInstance();
            
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.ManifestModule.Name.Contains("ECommerceNetCore.Persistance.dll") || x.ManifestModule.Name.Contains("ECommerceNetCore.Application.dll")).ToArray();
            builder.RegisterAssemblyTypes(assemblies).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }

        private void LoadRepositories(ContainerBuilder builder)
        {
            
        }
        private void LoadServices(ContainerBuilder builder)
        {
            
        }
    }
}
