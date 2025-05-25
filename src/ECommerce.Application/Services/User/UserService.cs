using Ecommerce.Shared.Utilities.Results;

namespace ECommerce.User;

public class UserService : IUserService
{
    IUserRepository _userRepo;

    public UserService(IUserRepository userRepo)
    {
        _userRepo = userRepo;
    }

    public IDataResult<GnlUser> AddUser(GnlUser user)
    {
        throw new NotImplementedException();
    }

    public IResult DeleteUser(int id)
    {
        throw new NotImplementedException();
    }

    public IResult UpdateUser(GnlUser user)
    {
        throw new NotImplementedException();
    }

    public IListResult<GnlUser> GetAllUsers(int statudId = 1, int start = 0, int take = 25)
    {
        var result = _userRepo.GetAllUsers(statudId, start, take);
        return null;
    }

    public IDataResult<GnlUser> GetUser(string userName, string userMail)
    {
        throw new NotImplementedException();
    }
}
