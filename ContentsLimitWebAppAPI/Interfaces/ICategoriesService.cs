using ContentsLimitWebAppAPI.Entities;

namespace ContentsLimitWebAppAPI.Interfaces {
  public interface ICategoriesService {
    Task<IEnumerable<Category>> GetCategoriesAsync();
    Task<int> InsertCategoryAsync(Category category);
    Task DeleteCategoryAsync(int id);
  }
}