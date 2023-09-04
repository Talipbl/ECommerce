using ECommerce.Application.Interfaces.Repositories;
using ECommerce.Domain.Entities;
using ECommerce.Persistance.Context;

namespace ECommerce.Persistance.Repositories.EFCore
{
    public class EfProductXmlRepository : EfBaseEntityRepository<GnlProductXml, ECommerceContext>, IProductXmlRepository
    {

    }
}
