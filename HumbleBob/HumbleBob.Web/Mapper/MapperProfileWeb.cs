using AutoMapper;
using HumbleBob.Bll.Dto;
using HumbleBob.Web.ViewModels;

namespace HumbleBob.Web.Mapper
{
    public class MapperProfileWeb : Profile
    {
        public MapperProfileWeb()
        {
            CreateMap<ItemDto, ItemViewModel>().ReverseMap();
        }
    }
}
