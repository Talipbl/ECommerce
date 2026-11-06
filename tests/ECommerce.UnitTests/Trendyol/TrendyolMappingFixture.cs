using ECommerce.Application;
using ECommerce.Trendyol;
using MapsterMapper;

namespace ECommerce.UnitTests.Trendyol;

public static class TrendyolMappingFixture
{
    private static readonly IMapper Mapper = new Mapper(MappingRegistration.CreateConfig());

    public static ITrendyolProductAdapter CreateProductAdapter() => new TrendyolProductAdapter(Mapper);

    public static ITrendyolOrderAdapter CreateOrderAdapter() => new TrendyolOrderAdapter(Mapper);
}
