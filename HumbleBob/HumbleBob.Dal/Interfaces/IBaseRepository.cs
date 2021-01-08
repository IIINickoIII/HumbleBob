using HumbleBob.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HumbleBob.Dal.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(Guid id);

        void Create(TEntity entity);

        void Update(TEntity entity);

        void SoftDelete(TEntity entity);

        void RecoverSoftDeleted(TEntity entity);
    }
}
