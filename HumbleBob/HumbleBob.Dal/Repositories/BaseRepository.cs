using HumbleBob.Dal.Contexts;
using HumbleBob.Dal.Entities;
using HumbleBob.Dal.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HumbleBob.Dal.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(HumbleBobContext context)
        {
            _dbSet = context.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _dbSet.SingleOrDefaultAsync(t => t.Id == id);
        }

        public void RecoverSoftDeleted(TEntity entity)
        {
            _dbSet.Find(entity.Id).IsDeleted = false;
        }

        public void SoftDelete(TEntity entity)
        {
            _dbSet.Find(entity.Id).IsDeleted = true;
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}
