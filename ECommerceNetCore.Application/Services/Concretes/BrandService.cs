using ECommerceNetCore.Application.Interfaces.Services;
using ECommerceNetCore.Application.Results;
using ECommerceNetCore.Domain.Entities;

namespace ECommerceNetCore.Application.Services.Concretes
{
    public class BrandService : IBrandService
    {
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
            throw new NotImplementedException();
        }

        public IResult UpdateBrand(DefBrand brand)
        {
            throw new NotImplementedException();
        }
    }
}
