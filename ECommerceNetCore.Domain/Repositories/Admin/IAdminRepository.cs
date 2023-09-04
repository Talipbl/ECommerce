using ECommerce.Core.Persistance;

namespace ECommerce.Admin
{
    public interface IAdminRepository : IBaseEntityRepository<DefAdmin>
    {
        DefAdmin GetAdmin(string nameOrMail);
    }
}
