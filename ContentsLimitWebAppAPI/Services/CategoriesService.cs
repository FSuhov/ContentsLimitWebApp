using ContentsLimitWebAppAPI.Entities;
using ContentsLimitWebAppAPI.Interfaces;

namespace ContentsLimitWebAppAPI.Services {

  /// <summary>
  /// Contains implementation of business logic for managing the Categories.
  /// </summary>
  public class CategoriesService : ICategoriesService {

    private readonly ICategoriesRepository _categoriesRepository;

    /// <summary>
    /// Initializes new instance of ICategoriesService.
    /// </summary>
    /// <param name="itemsRepository">The instance of Categories repository</param>
    public CategoriesService(ICategoriesRepository categoriesRepository) { 
      _categoriesRepository = categoriesRepository;
    }

    /// <summary>
    /// Gets Categories from Database and returns it to User Interface.
    /// </summary>
    /// <returns>Collection of Categories</returns>
    public async Task<IEnumerable<Category>> GetCategoriesAsync() {
      return await _categoriesRepository.GetCategories();
    }    
  }
}