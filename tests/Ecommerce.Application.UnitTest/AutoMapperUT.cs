using AutoMapper;
using ECommerce.Trendyol;

namespace Ecommerce.Application.UnitTest;

[TestClass]
public class AutoMapperUT
{
    [TestMethod]
    public void Should_Validate_Trendyol_Configurations()
    {
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(typeof(TrendyolTypeConvertProfile));
            cfg.AddProfile(typeof(TrendyolBaseResultMappingProfile));
            cfg.AddProfile(typeof(TrendyolProductMappingProfile));
            cfg.AddProfile(typeof(TrendyolOrderMappingProfile));
        });

        configuration.AssertConfigurationIsValid();
    }
}
