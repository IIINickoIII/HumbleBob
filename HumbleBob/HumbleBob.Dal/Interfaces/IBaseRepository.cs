using HumbleBob.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;

namespace HumbleBob.Dal.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(Guid id);

        void Create(TEntity entity);

        void Update(TEntity entity);

        void UpdateRange(IEnumerable<TEntity> entities);

        void HardDelete(TEntity entity);

        void HardDeleteRange(IEnumerable<TEntity> entities);

        void SoftDelete(TEntity entity);

        void RecoverSoftDeleted(TEntity entity);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include);

        Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include);

        IEnumerable<TEntity> GetAll<TSortField>(Expression<Func<TEntity, TSortField>> orderBy, bool @ascending);

        Task<IEnumerable<TEntity>> GetAll(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include);
    }
}
