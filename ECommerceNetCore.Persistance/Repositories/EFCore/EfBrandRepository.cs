using ECommerce.Core.Persistance;
using ECommerce.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Brand
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
