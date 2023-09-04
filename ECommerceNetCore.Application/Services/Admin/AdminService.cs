using ECommerce.Application.Interfaces.Services.Admin;

namespace ECommerce.Admin
{
    public class AdminService : IAdminService
    {
        IAdminRepository _adminRepo;

        public AdminService(IAdminRepository adminRepo)
        {
            _adminRepo = adminRepo;
        }

        public IDataResult<DefAdmin> AddAdmin(DefAdmin admin)
        {
            throw new NotImplementedException();
        }

        public IResult DeleteAdmin(int adminId)
        {
            throw new NotImplementedException();
        }

        [LogAspect]
        [CacheAspect(Duration = 300)]
        public IDataResult<DefAdmin> GetAdmin(int adminId)
        {
            throw new NotImplementedException();
        }
        public IDataResult<DefAdmin> GetAdmin(string nameOrMail)
        {
            var result = _adminRepo.GetAdmin(nameOrMail);
            return new DataResult<DefAdmin>(result, true);
        }

        public IListResult<DefAdmin> GetAdmins(int statusId = 1)
        {
            throw new NotImplementedException();
        }

        public IResult UpdateAdmin(DefAdmin admin)
        {
            throw new NotImplementedException();
        }
    }
}
