using ContentsLimitWebAppAPI.Entities;
using ContentsLimitWebAppAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ContentsLimitWebAppAPI.Controllers {

  /// <summary>
  /// Controller, exposing the API for managing Items. 
  /// </summary>

  [ApiController]
  [Route("[controller]")]
  public class ItemsController : ControllerBase {

    private readonly IItemsService _itemsService;

    /// <summary>
    /// Initializes new instance of ItemsController.
    /// </summary>
    /// <param name="categoriesService">Instance of ItemsService</param>
    public ItemsController(IItemsService itemsService) {      
      _itemsService = itemsService;
    }

    /// <summary>
    /// Fetches Items. Handles http request GET "{url}/items".
    /// </summary>
    /// <returns>Collection of Items</returns>
    [HttpGet(Name = "GetItems")]
    public async Task<ActionResult<IEnumerable<Item>>> GetItems() {
      var items = await _itemsService.GetItemsAsync();
      return Ok(items);
    }

    /// <summary>
    /// Inserts new Item. Handles http request POST "{url}/items".
    /// </summary>
    /// <param name="item">Item object passed in body</param>
    /// <returns>Id of inserted Item</returns>
    [HttpPost(Name = "InsertItem")]
    public async Task<ActionResult<int>> InsertItem(Item item) {      
      var insertedId = await _itemsService.InsertItemAsync(item);
      return Ok(insertedId);
    }

    /// <summary>
    /// Inserts new Item. Handles http request DELETE "{url}/items?id=1".
    /// </summary>
    /// <param name="item">Item Id (in url)</param>
    [HttpDelete(Name = "DeleteItem")]
    public async Task<IActionResult> DeleteItem(int id) {
      await _itemsService.DeleteItemAsync(id);
      return NoContent();
    }
  }
}