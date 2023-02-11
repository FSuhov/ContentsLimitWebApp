using ContentsLimitWebAppAPI.Entities;
using ContentsLimitWebAppAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ContentsLimitWebAppAPI.Controllers {

  [ApiController]
  [Route("[controller]")]
  public class ItemsController : ControllerBase {
    private readonly IItemsService _itemsService;
    public ItemsController(IItemsService itemsService) {      
      _itemsService = itemsService;
    }

    [HttpGet(Name = "GetItems")]
    public async Task<ActionResult<IEnumerable<Item>>> GetItems() {
      var items = await _itemsService.GetItemsAsync();
      return Ok(items);
    }

    [HttpPost(Name = "InsertItem")]
    public async Task<ActionResult<int>> InsertItem(Item item) {      
      var insertedId = await _itemsService.InsertItemAsync(item);
      return Ok(insertedId);
    }

    [HttpDelete(Name = "DeleteItem")]
    public async Task<IActionResult> DeleteItem(int id) {
      await _itemsService.DeleteItemAsync(id);
      return NoContent();
    }
  }
}