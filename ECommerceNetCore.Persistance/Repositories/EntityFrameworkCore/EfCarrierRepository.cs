using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Domain.Entities;
using ECommerceNetCore.Persistance.Context;

namespace ECommerceNetCore.Persistance.Repositories.EntityFrameworkCore
{
    public class EfCarrierRepository : EfBaseEntityRepository<DefCarrier, EcommerceNetCoreContext>, ICarrierRepository
    {

    }
}
