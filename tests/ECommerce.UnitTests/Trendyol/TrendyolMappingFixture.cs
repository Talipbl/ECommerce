using AutoMapper;
using ECommerce.Trendyol;

namespace ECommerce.UnitTests.Trendyol;

public static class TrendyolMappingFixture
{
    private static readonly IMapper Mapper = new MapperConfiguration(cfg =>
    {
        cfg.AddProfile<TrendyolTypeConvertProfile>();
        cfg.AddProfile<TrendyolBaseResultMappingProfile>();
        cfg.AddProfile<TrendyolProductMappingProfile>();
        cfg.AddProfile<TrendyolOrderMappingProfile>();
    }).CreateMapper();

    public static ITrendyolProductAdapter CreateProductAdapter() => new TrendyolProductAdapter(Mapper);

    public static ITrendyolOrderAdapter CreateOrderAdapter() => new TrendyolOrderAdapter(Mapper);
}
