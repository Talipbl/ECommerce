using ECommerceNetCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Application.Interfaces
{
    public interface IAdminRepository : IBaseEntityRepository<DefAdmin>
    {
        DefAdmin GetAdmin(string nameOrMail);
    }
}
