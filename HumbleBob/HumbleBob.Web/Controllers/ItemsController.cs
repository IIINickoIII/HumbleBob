using AutoMapper;
using HumbleBob.Bll.Dto;
using HumbleBob.Bll.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using HumbleBob.Web.ViewModels;

namespace HumbleBob.Web.Controllers
{
    public class ItemsController : Controller
    {
        private readonly IItemService _itemService;
        private readonly IMapper _mapper;

        public ItemsController(IItemService itemService, IMapper mapper)
        {
            _itemService = itemService;
            _mapper = mapper;
        }

        [Route("")]
        public async Task<IActionResult> GetReadOnlyItems()
        {
            var items = await _itemService.GetAllAsync() ?? new List<ItemDto>();
            return View("ItemsReadOnlyList", items);
        }

        [Route("/items/edit")]
        public async Task<IActionResult> GetForEditItems()
        {
            var items = await _itemService.GetAllAsync() ?? new List<ItemDto>();
            return View("ItemsForEditList", items);
        }

        [Route("/items/create")]
        public IActionResult CreateItem()
        {
            var itemViewModel = new ItemViewModel();
            return View("ItemForm", itemViewModel);
        }
    }
}
