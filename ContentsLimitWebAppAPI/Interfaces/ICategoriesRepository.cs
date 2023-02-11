using ContentsLimitWebAppAPI.Entities;

namespace ContentsLimitWebAppAPI.Interfaces {
  public interface ICategoriesRepository {
    Task<IEnumerable<Category>> GetCategories();
    Task<int> InsertCategory(Category category);
    Task DeleteCategory(int id);
  }
}