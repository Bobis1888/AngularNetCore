using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AngularDotnetCore.Models;

namespace AngularDotnetCore.Controllers
{
    [ApiController]
    [Route("api/items")]
    public class ItemController : Controller
    {
        ApplicationContext db;
        public ItemController(ApplicationContext context)
        {
            db = context;
            if(!db.Items.Any())
            {
                //add news in base 
                // db.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Item> Get()
        {
            return RssService.GetItemsFromRss("habr");
        }

        [HttpGet("{postId}")]
        public Item Get(string postId)
        {
            return RssService.GetItemBody(postId);
        }

        [HttpPost]
        public IActionResult Post(Item Item)
        {
            if(ModelState.IsValid)
            {
                db.Items.Add(Item);
                db.SaveChanges();
                return Ok(Item);
            }
            return BadRequest(ModelState);
        }
        [HttpPut]
        public IActionResult Put(Item Item)
        {
            if(ModelState.IsValid)
            {
                db.Update(Item);
                db.SaveChanges();
                return Ok(Item);
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Item = db.Items.FirstOrDefault(x => x.Id == id);
            if(Item != null)
            {
                db.Items.Remove(Item);
                db.SaveChanges();
            }
            return Ok(Item);
        }
    }
}