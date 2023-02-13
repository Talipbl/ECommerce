using ECommerceNetCore.Application.Interfaces.Services;
using ECommerceNetCore.Application.Results;
using ECommerceNetCore.Domain.Common;
using ECommerceNetCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Application.Services.Concretes
{
    public class AdminService : IAdminService
    {
        public IDataResult<DefAdmin> AddAdmin(DefAdmin admin)
        {
            throw new NotImplementedException();
        }

        public IResult DeleteAdmin(int adminId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<DefAdmin> GetAdmin(int adminId)
        {
            throw new NotImplementedException();
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
