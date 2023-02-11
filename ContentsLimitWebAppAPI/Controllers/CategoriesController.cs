using ContentsLimitWebAppAPI.Entities;
using ContentsLimitWebAppAPI.Interfaces;
using ContentsLimitWebAppAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContentsLimitWebAppAPI.Controllers {

  [ApiController]
  [Route("[controller]")]
  public class CategoriesController : ControllerBase {
    
    private readonly ICategoriesService _categoriesService;
    public CategoriesController(ICategoriesService categoriesService) {
      _categoriesService = categoriesService;
    }

    [HttpGet(Name = "GetCategory")]
    public async Task<ActionResult<IEnumerable<Item>>> GetItems() {
      var categories = await _categoriesService.GetCategoriesAsync();
      return Ok(categories);
    }

    [HttpPost(Name = "InsertCategory")]
    public async Task<ActionResult<int>> InsertCategory(Category category) {

      var insertedId = await _categoriesService.InsertCategoryAsync(category);
      return Ok(insertedId);
    }

    [HttpDelete(Name = "DeleteCategory")]
    public async Task<IActionResult> DeleteCategory(int id) {
      await _categoriesService.DeleteCategoryAsync(id);
      return NoContent();
    }
  }
}