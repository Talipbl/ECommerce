using ECommerce.Domain;

namespace ECommerce.Admin
{
    public interface IAdminRepository : IBaseEntityRepository<DefAdmin>
    {
        DefAdmin GetAdmin(string nameOrMail);
    }
}
