using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Domain.Entities;
using ECommerceNetCore.Persistance.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace ECommerceNetCore.Persistance.Repositories
{
    public class EfSystemRepository
    {
        private object BaseOperation(object entity, EntityState state)
        {
            using (EcommerceNetCoreContext context = new EcommerceNetCoreContext())
            {
                context.Entry(entity).State = state;
                if (context.SaveChanges() > 0)
                {
                    return entity;
                }
                return entity;
            }
        }
        public void LogError(SysErrorLog errorLog)
        {
            BaseOperation(errorLog, EntityState.Added);
        }
    }
}
