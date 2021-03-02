using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AngularNetCore.Models;
using AngularNetCore.Services;

namespace AngularNetCore.Controllers
{
    [ApiController]
    [Route("api/items")]
    public class ItemController : Controller
    {
        private ItemService ItemService;
        public ItemController(ItemService itemService)
        {
            this.ItemService = itemService;
        }
        [HttpGet("{nameSource}/{flow}")]
        public IEnumerable<Item> Get(string nameSource , string flow )
        {
            return ItemService.GetItems(nameSource,flow);
        }
        [HttpGet("{nameSource}/{flow}/{postId}")]
        public Item Get(string nameSource,string flow ,string postId)
        {
            return ItemService.GetItem(nameSource,flow,postId);
        }
    }
}