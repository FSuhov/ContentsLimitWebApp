using ContentsLimitWebAppAPI.Entities;
using ContentsLimitWebAppAPI.Interfaces;

namespace ContentsLimitWebAppAPI.Services {
  public class CategoriesService : ICategoriesService {

    private readonly ICategoriesRepository _categoriesRepository;
    public CategoriesService(ICategoriesRepository categoriesRepository) { 
      _categoriesRepository = categoriesRepository;
    }
    public async Task<IEnumerable<Category>> GetCategoriesAsync() {
      return await _categoriesRepository.GetCategories();
    }

    public async Task<int> InsertCategoryAsync(Category category) {
      return await _categoriesRepository.InsertCategory(category);
    }

    public async Task DeleteCategoryAsync(int id) {
      await _categoriesRepository.DeleteCategory(id);
    }
  }
}