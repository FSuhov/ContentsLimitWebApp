using ContentsLimitWebAppAPI.Entities;

namespace ContentsLimitWebAppAPI.Interfaces {

  /// <summary>
  /// Defines data access methods for managing the Categories in Database.
  /// </summary>
  public interface ICategoriesRepository {

    /// <summary>
    /// Selects all Categories from Database.
    /// </summary>
    /// <returns>Collection of Categories records</returns>
    Task<IEnumerable<Category>> GetCategories();
  }
}