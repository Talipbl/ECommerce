using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceNetCore.Domain.Entities;

namespace ECommerceNetCore.Domain.Entities
{
    public class BaseEntity : IEntity
    {
        public int Id { get; set; }
    }
}
