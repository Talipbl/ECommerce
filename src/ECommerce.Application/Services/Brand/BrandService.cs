using Ecommerce.Shared.Utilities.Results;

namespace ECommerce.Brand;

public class BrandService : IBrandService
{
    IBrandRepository _brandRepo;

    public BrandService(IBrandRepository brandRepo)
    {
        _brandRepo = brandRepo;
    }

    public IDataResult<DefBrand> AddBrand(DefBrand brand)
    {
        throw new NotImplementedException();
    }

    public IResult DeleteBrand(int brandId)
    {
        throw new NotImplementedException();
    }

    public IDataResult<DefBrand> GetBrand(int brandId)
    {
        throw new NotImplementedException();
    }

    public IListResult<DefBrand> GetBrands()
    {
        //return _brandRepo.GetBrands();
        return null;
    }

    public IResult UpdateBrand(DefBrand brand)
    {
        throw new NotImplementedException();
    }
}
