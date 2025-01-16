using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using ECommerce.Admin;
using ECommerce.Brand;
using ECommerce.Carrier;
using ECommerce.Category;
using ECommerce.Core.Application;
using ECommerce.DiscountCoupon;
using ECommerce.Manufacturer;
using ECommerce.Order;
using ECommerce.Product;
using ECommerce.Systems;
using ECommerce.User;
using ECommerce.Xml;

namespace ECommerce.Application
{
    public class AutofacEFModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfAdminRepository>().As<IAdminRepository>().SingleInstance();

            builder.RegisterType<EfBrandRepository>().As<IBrandRepository>().SingleInstance();

            builder.RegisterType<EfCarrierRepository>().As<ICarrierRepository>().SingleInstance();

            builder.RegisterType<EfCategoryRepository>().As<ICategoryRepository>().SingleInstance();

            builder.RegisterType<EfDiscountCouponRepository>().As<IDiscountCouponRepository>().SingleInstance();

            builder.RegisterType<EfManufacturerRepository>().As<IManufacturerRepository>().SingleInstance();

            builder.RegisterType<EfOrderPaymentRepository>().As<IOrderPaymentRepository>().SingleInstance();

            builder.RegisterType<EfOrderProductRepository>().As<IOrderProductRepository>().SingleInstance();

            builder.RegisterType<EfOrderRepository>().As<IOrderRepository>().SingleInstance();

            builder.RegisterType<EfProductCategoryRepository>().As<IProductCategoryRepository>().SingleInstance();

            builder.RegisterType<EfProductImageRepository>().As<IProductImageRepository>().SingleInstance();

            builder.RegisterType<EfProductOptionRepository>().As<IProductOptionRepository>().SingleInstance();

            builder.RegisterType<EfProductPriceRepository>().As<IProductPriceRepository>().SingleInstance();

            builder.RegisterType<EfProductRepository>().As<IProductRepository>().SingleInstance();

            builder.RegisterType<EfProductXmlRepository>().As<IProductXmlRepository>().SingleInstance();

            builder.RegisterType<EfSystemRepository>().As<ISystemRepository>().SingleInstance();

            builder.RegisterType<EfUserCouponRepository>().As<IUserCouponRepository>().SingleInstance();

            builder.RegisterType<EfUserMailQueueRepository>().As<IUserMailQueueRepository>().SingleInstance();

            builder.RegisterType<EfUserRepository>().As<IUserRepository>().SingleInstance();

            builder.RegisterType<EfXmlSchedulereLogRepository>().As<IXmlSchedulereLogRepository>().SingleInstance();

            builder.RegisterType<EfXmlSchedulereRepository>().As<IXmlSchedulereRepository>().SingleInstance();


            var assemblies = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assemblies).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
