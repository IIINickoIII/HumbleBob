using AutoMapper;
using HumbleBob.Bll.Dto;
using HumbleBob.Dal.Entities;

namespace HumbleBob.Bll.Mapper
{
    public class MapperProfileBll : Profile
    {
        public MapperProfileBll()
        {
            CreateMap<Item, ItemDto>().ReverseMap();
        }
    }
}
