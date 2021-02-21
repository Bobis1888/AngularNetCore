using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AngularDotnetCore.Models;
using AngularDotnetCore.Services;

namespace AngularDotnetCore.Controllers
{
    [ApiController]
    [Route("api/items")]
    public class ItemController : Controller
    {
        private ItemService itemService;
        public ItemController(ItemService itemService)
        {
            this.itemService = itemService;
        }
        [HttpGet("{nameSource}/{flow}")]
        public IEnumerable<Item> Get(string nameSource , string flow )
        {
            return itemService.GetItems(nameSource,flow);
        }
        [HttpGet("{nameSource}/{flow}/{postId}")]
        public Item Get(string nameSource,string flow ,string postId)
        {
            return itemService.GetItem(nameSource,flow,postId);
        }
    }
}