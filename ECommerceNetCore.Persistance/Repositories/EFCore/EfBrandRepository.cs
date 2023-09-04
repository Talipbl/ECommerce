using ECommerce.Application.Interfaces.Repositories;
using ECommerce.Application.Utilities;
using ECommerce.Application.Utilities.Results.Abstracts;
using ECommerce.Domain.Entities;
using ECommerce.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistance.Repositories.EFCore
{
    public class EfBrandRepository : EfBaseEntityRepository<DefBrand, ECommerceContext>, IBrandRepository
    {
        public IListResult<DefBrand> GetBrands()
        {
            var result = GetAll().ToList();
            return new ListResult<DefBrand>(result, result.Count);
        }
    }
}
