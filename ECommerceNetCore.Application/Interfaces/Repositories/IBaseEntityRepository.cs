using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using ECommerceNetCore.Domain.Entities;

namespace ECommerceNetCore.Application.Interfaces
{
    public interface IBaseEntityRepository<T> where T : class, IEntity, new()
    {
        public T Add(T entity);
        public bool Delete(T entity);
        public T Get(Expression<Func<T, bool>> filter);
        public IEnumerable<T> GetAll<TSorted>(Expression<Func<T, bool>> filter = null, Expression<Func<T, TSorted>> sortedBy = null, int sortOrder = (int)SortOrder.Ascending, params Expression<Func<T, object>>[] includes);
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null);
        IEnumerable<T> GetAll<T>(Expression<Func<T, bool>> filter = null) where T : class, IEntity, new();
        public int GetCount();
        public bool Update(T entity);
    }
}
