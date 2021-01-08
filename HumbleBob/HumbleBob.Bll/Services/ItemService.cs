using AutoMapper;
using HumbleBob.Bll.Dto;
using HumbleBob.Bll.Interfaces;
using HumbleBob.Dal.Entities;
using HumbleBob.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HumbleBob.Bll.Services
{
    public class ItemService : IItemService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public ItemService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public void Create(ItemDto itemDto)
        {
            var item = _mapper.Map<Item>(itemDto);
            _uow.ItemRepository.Create(item);
            _uow.Save();
        }

        public async Task<IEnumerable<ItemDto>> GetAllAsync()
        {
            var items = await _uow.ItemRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<ItemDto>>(items);
        }

        public async Task<ItemDto> GetByIdAsync(Guid id)
        {
            var item = await _uow.ItemRepository.GetByIdAsync(id);

            return _mapper.Map<ItemDto>(item);
        }

        public void RecoverSoftDeleted(ItemDto itemDto)
        {
            _uow.ItemRepository.RecoverSoftDeleted(_mapper.Map<Item>(itemDto));
            _uow.Save();
        }

        public void SoftDelete(ItemDto itemDto)
        {
            _uow.ItemRepository.SoftDelete(_mapper.Map<Item>(itemDto));
            _uow.Save();
        }

        public void Update(ItemDto itemDto)
        {
            _uow.ItemRepository.Update(_mapper.Map<Item>(itemDto));
            _uow.Save();
        }
    }
}
