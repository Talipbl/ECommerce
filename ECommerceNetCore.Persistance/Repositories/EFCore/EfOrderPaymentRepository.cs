using ECommerce.Application.Interfaces.Repositories;
using ECommerce.Domain.Entities;
using ECommerce.Persistance.Context;

namespace ECommerce.Persistance.Repositories.EFCore
{
    public class EfOrderPaymentRepository : EfBaseEntityRepository<GnlOrderPayment, ECommerceContext>, IOrderPaymentRepository
    {

    }
}
