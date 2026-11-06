using ECommerce.Core.Domain;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace ECommerce.Core.Persistence
{
    public interface IBaseEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        TEntity Add(TEntity entity);
        T Add<T>(T entity);
        bool Delete(TEntity entity);
        TEntity Get(Expression<Func<TEntity, bool>> filter);
        T Get<T>(Expression<Func<T, bool>> filter) where T : class, IEntity, new();
        IEnumerable<TEntity> GetAll<TSorted>(Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, TSorted>> sortedBy = null, int sortOrder = (int)SortOrder.Ascending, int skip = 0, int take = 0, params Expression<Func<TEntity, object>>[] includes);
        public IEnumerable<T> GetAll<TSorted, T>(Expression<Func<T, bool>> filter = null, Expression<Func<T, TSorted>> sortedBy = null, int sortOrder = (int)SortOrder.Ascending, int skip = 0, int take = 0, params Expression<Func<T, object>>[] includes) where T : class, IEntity, new();
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
        IEnumerable<T> GetAll<T>(Expression<Func<T, bool>> filter = null) where T : class, IEntity, new();
        int GetCount();
        int GetCount<T>() where T : class, IEntity, new();
        bool Update(TEntity entity);
        bool Update<T>(T entity);
    }
}
