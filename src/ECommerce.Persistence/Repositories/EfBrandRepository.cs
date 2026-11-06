using ECommerce.Core.Persistence;
using ECommerce.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Brand;

public class EfBrandRepository : EfBaseEntityRepository<DefBrand, ECommerceContext>, IBrandRepository
{
    public ICollection<DefBrand> GetBrands()
    {
        var result = GetAll().ToList();
        return result;
    }
}
