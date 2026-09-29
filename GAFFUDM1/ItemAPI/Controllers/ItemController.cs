using ItemDataLibrary.Data;
using ItemDataLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ItemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private ISqlData _db;

        public ItemController(ISqlData db)
        {
            _db = db;
        }

        // GET: api/Item/list
        [AllowAnonymous]
        [HttpGet("list")]
        public ActionResult ListItems()
        {
            List<ItemModel> items = _db.ListItems();
            return Ok(items);
        }

        // GET: api/Item/1
        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult ShowItemDetails(int id)
        {
            ItemModel item = _db.ShowItemDetails(id);
            return Ok(item);
        }

        // POST: api/Item/add
        [AllowAnonymous]
        [HttpPost("add")]
        public ActionResult AddItem([FromBody] ItemForm item)
        {
            _db.AddItem(item);
            return Ok("Item added.");
        }

        // PUT: api/Item/update/1
        [AllowAnonymous]
        [HttpPut("update/{id}")]
        public ActionResult UpdateItem(int id, [FromBody] ItemForm item)
        {
            _db.UpdateItem(id, item);
            return Ok("Item updated.");
        }

        // DELETE: api/Item/delete/1
        [AllowAnonymous]
        [HttpDelete("delete/{id}")]
        public ActionResult DeleteItem(int id)
        {
            _db.DeleteItem(id);
            return Ok("Item deleted.");
        }
    }
}