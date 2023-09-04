using ECommerce.Core.Application;

namespace ECommerce.Brand;

public interface IBrandService
{
    IDataResult<DefBrand> AddBrand(DefBrand brand);
    IResult UpdateBrand(DefBrand brand);
    IResult DeleteBrand(int brandId);
    IListResult<DefBrand> GetBrands();
    IDataResult<DefBrand> GetBrand(int brandId);
}
