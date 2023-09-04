using ECommerce.Application.Utilities.Results.Abstracts;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Interfaces.Services.Brand
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
