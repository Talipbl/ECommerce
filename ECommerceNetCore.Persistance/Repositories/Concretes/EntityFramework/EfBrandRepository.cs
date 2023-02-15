using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Domain.Entities;
using ECommerceNetCore.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Persistance.Repositories
{
    public class EfBrandRepository : EfBaseEntityRepository<DefBrand, EcommerceNetCoreContext>, IBrandRepository
    {

    }
}
