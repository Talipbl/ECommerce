using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Application.Results;
using ECommerceNetCore.Domain.Entities;

namespace ECommerceNetCore.Application.Services
{
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
            return _brandRepo.GetBrands();
        }

        public IResult UpdateBrand(DefBrand brand)
        {
            throw new NotImplementedException();
        }
    }
}
