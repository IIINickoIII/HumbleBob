using HumbleBob.Bll.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HumbleBob.Bll.Interfaces
{
    public interface IItemService
    {
        Task<IEnumerable<ItemDto>> GetAllAsync();

        Task<ItemDto> GetByIdAsync(Guid id);

        void Create(ItemDto item);

        void Update(ItemDto item);

        void SoftDelete(ItemDto item);

        void RecoverSoftDeleted(ItemDto item);
    }
}
