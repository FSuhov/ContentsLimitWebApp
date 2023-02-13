using ContentsLimitWebAppAPI.Entities;
using ContentsLimitWebAppAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ContentsLimitWebAppAPI.Controllers {

  /// <summary>
  /// Controller, exposing the API for managing Categories. 
  /// </summary>
  [ApiController]
  [Route("[controller]")]
  public class CategoriesController : ControllerBase {
    
    private readonly ICategoriesService _categoriesService;

    /// <summary>
    /// Initializes new instance of CategoriesController.
    /// </summary>
    /// <param name="categoriesService">Instance of CategoryService</param>
    public CategoriesController(ICategoriesService categoriesService) {
      _categoriesService = categoriesService;
    }

    /// <summary>
    /// Fetches Categories. Handles http request GET "{url}/categories".
    /// </summary>
    /// <returns>Collection of Categories</returns>
    [HttpGet(Name = "GetCategory")]
    public async Task<ActionResult<IEnumerable<Item>>> GetItems() {
      var categories = await _categoriesService.GetCategoriesAsync();
      return Ok(categories);
    }    
  }
}