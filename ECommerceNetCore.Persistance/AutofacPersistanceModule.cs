using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using ECommerce.Persistance.Repositories.EFCore;

namespace ECommerce.Persistance
{
    public class AutofacPersistanceModule : Module
    {
        //Autofac
        protected override void Load(ContainerBuilder builder)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true).Build();

            builder.RegisterType<CacheManager>().As<ICacheManager>().SingleInstance();
            builder.RegisterType<DbLogManager>().As<ILogManager>().SingleInstance();
            builder.RegisterInstance(configuration);

            LoadRepositories(builder);
            LoadServices(builder);

            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.ManifestModule.Name.Contains("ECommerce.Persistance.dll") || x.ManifestModule.Name.Contains("ECommerce.Application.dll")).ToArray();
            builder.RegisterAssemblyTypes(assemblies).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }

        private void LoadRepositories(ContainerBuilder builder)
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
        }
        private void LoadServices(ContainerBuilder builder)
        {
            builder.RegisterType<AdminService>().As<IAdminService>().SingleInstance();
            builder.RegisterType<AuthService>().As<IAuthService>().SingleInstance();
            builder.RegisterType<BrandService>().As<IBrandService>().SingleInstance();
            builder.RegisterType<CarrierService>().As<ICarrierService>().SingleInstance();
            builder.RegisterType<CategoryService>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<ManufacturerService>().As<IManufacturerService>().SingleInstance();
            builder.RegisterType<OrderService>().As<IOrderService>().SingleInstance();
            builder.RegisterType<ProductService>().As<IProductService>().SingleInstance();
            builder.RegisterType<SystemService>().As<ISystemService>().SingleInstance();
            builder.RegisterType<UserService>().As<IUserService>().SingleInstance();
        }
    }
}
