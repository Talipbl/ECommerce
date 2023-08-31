using ECommerceNetCore.Application.Utilities;
using ECommerceNetCore.Domain.Entities;

namespace ECommerceNetCore.Application.Interfaces
{
    public interface IBrandService
    {
        IDataResult<DefBrand> AddBrand(DefBrand brand);
        IResult UpdateBrand(DefBrand brand);
        IResult DeleteBrand(int brandId);
        IListResult<DefBrand> GetBrands();
        IDataResult<DefBrand> GetBrand(int brandId);
    }
}
