using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using ECommerce.Admin;
using ECommerce.Application;
using ECommerce.Brand;
using ECommerce.Carrier;
using ECommerce.Category;
using ECommerce.DiscountCoupon;
using ECommerce.Manufacturer;
using ECommerce.Order;
using ECommerce.Product;
using ECommerce.Systems;
using ECommerce.Trendyol;
using ECommerce.User;
using ECommerce.Xml;

namespace ECommerce.Application
{
    public class AutofacApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AdminAuthService>().As<IAuthService>().SingleInstance();

            builder.RegisterType<AdminService>().As<IAdminService>().SingleInstance();

            builder.RegisterType<BrandService>().As<IBrandService>().SingleInstance();

            builder.RegisterType<CarrierService>().As<ICarrierService>().SingleInstance();

            builder.RegisterType<CategoryService>().As<ICategoryService>().SingleInstance();

            builder.RegisterType<SubCategoryService>().As<ISubCategoryService>().SingleInstance();

            builder.RegisterType<DiscountService>().As<IDiscountService>().SingleInstance();

            builder.RegisterType<ManufacturerService>().As<IManufacturerService>().SingleInstance();

            builder.RegisterType<OrderService>().As<IOrderService>().SingleInstance();

            builder.RegisterType<OrderPaymentService>().As<IOrderPaymentService>().SingleInstance();

            builder.RegisterType<OrderProductService>().As<IOrderProductService>().SingleInstance();

            builder.RegisterType<ProductService>().As<IProductService>().SingleInstance();

            builder.RegisterType<ProductCategoryService>().As<IProductCategoryService>().SingleInstance();

            builder.RegisterType<ProductImageService>().As<IProductImageService>().SingleInstance();

            builder.RegisterType<ProductOptionService>().As<IProductOptionService>().SingleInstance();

            builder.RegisterType<ProductPriceService>().As<IProductPriceService>().SingleInstance();

            builder.RegisterType<SystemService>().As<ISystemService>().SingleInstance();

            builder.RegisterType<TrendyolProductService>().As<ITrendyolProductService>().SingleInstance();

            builder.RegisterType<UserAddressService>().As<IUserAddressService>().SingleInstance();

            builder.RegisterType<UserCouponService>().As<IUserCouponService>().SingleInstance();

            builder.RegisterType<UserService>().As<IUserService>().SingleInstance();

            builder.RegisterType<XmlSchedulerService>().As<IXmlSchedulerService>().SingleInstance();

            builder.RegisterType<XmlService>().As<IXmlService>().SingleInstance();



            var assemblies = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assemblies).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
