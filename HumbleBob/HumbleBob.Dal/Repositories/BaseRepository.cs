using HumbleBob.Dal.Entities;
using HumbleBob.Dal.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HumbleBob.Dal.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly IQueryable<TEntity> _queryableDbSet;

        public BaseRepository(DbContext context)
        {
            _dbSet = context.Set<TEntity>();
            _queryableDbSet = _dbSet;
        }

        public void Create(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _dbSet.UpdateRange(entities);
        }

        public void HardDelete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void HardDeleteRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _dbSet.SingleOrDefaultAsync(t => t.Id == id);
        }

        public void SoftDelete(TEntity entity)
        {
            _dbSet.Find(entity.Id).IsDeleted = true;
        }

        public void RecoverSoftDeleted(TEntity entity)
        {
            _dbSet.Find(entity.Id).IsDeleted = false;
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include)
        {
            return include(_queryableDbSet).Where(predicate).AsNoTracking();
        }

        public async Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().SingleAsync(predicate);
        }

        public async Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include)
        {
            return await include(_queryableDbSet).AsNoTracking().SingleAsync(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public IEnumerable<TEntity> GetAll<TSortField>(Expression<Func<TEntity, TSortField>> orderBy, bool @ascending)
        {
            return ascending ? _dbSet.OrderBy(orderBy) : _dbSet.OrderByDescending(orderBy);
        }

        public async Task<IEnumerable<TEntity>> GetAll(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include)
        {
            return await include(_queryableDbSet).AsNoTracking().ToListAsync();
        }
    }
}
