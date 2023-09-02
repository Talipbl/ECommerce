using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Application.Utilities;
using ECommerceNetCore.Domain.Entities;
using ECommerceNetCore.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Persistance.Repositories.EntityFrameworkCore
{
    public class EfBrandRepository : EfBaseEntityRepository<DefBrand, EcommerceNetCoreContext>, IBrandRepository
    {
        public IListResult<DefBrand> GetBrands()
        {
            var result = GetAll().ToList();
            return new ListResult<DefBrand>(result, result.Count);
        }
    }
}
