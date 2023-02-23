using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ECommerceNetCore.Application.Interfaces;
using ECommerceNetCore.Domain.Entities;

namespace ECommerceNetCore.Persistance.Repositories
{
    public class EfBaseEntityRepository<TEntity, TContext> : IBaseEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public TEntity Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Entry(entity).State = EntityState.Added;
                if (context.SaveChanges() > 0)
                {
                    return entity;
                }
                return entity;
            }
        }

        public bool Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Entry(entity).State = EntityState.Deleted;
                if (context.SaveChanges() > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().FirstOrDefault(filter);
            }
        }

        public IEnumerable<TEntity> GetAll<TSorted>(Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, TSorted>> sortedBy = null, int sortOrder = (int)SortOrder.Ascending, params Expression<Func<TEntity, object>>[] includes)
        {
            using (TContext context = new TContext())
            {
                IQueryable<TEntity> query = context.Set<TEntity>();
                query = includes.Aggregate(query, (current, child) => current.Include(child));
                var result = filter != null ? query.Where(filter) : query;
                result = sortedBy != null ? (sortOrder == (int)SortOrder.Ascending ? result.OrderBy(sortedBy) : result.OrderByDescending(sortedBy)) : result;
                return result.ToList();
            }
        }
        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                IQueryable<TEntity> query = context.Set<TEntity>();
                return filter != null ? query.Where(filter).ToList() : query.ToList();
            }
        }
        public IEnumerable<T> GetAll<T>(Expression<Func<T, bool>> filter = null) where T : class, IEntity, new()
        {
            using (TContext context = new TContext())
            {
                IQueryable<T> query = context.Set<T>();
                return filter != null ? query.Where(filter).ToList() : query.ToList();
            }
        }

        public int GetCount()
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().Count();
            }
        }

        public bool Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                if (context.SaveChanges() > 0)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
