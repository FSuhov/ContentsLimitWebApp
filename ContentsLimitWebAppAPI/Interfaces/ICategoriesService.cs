using ContentsLimitWebAppAPI.Entities;

namespace ContentsLimitWebAppAPI.Interfaces {

  /// <summary>
  /// Contains definitions of business logic methods for Categories Service.
  /// </summary>
  public interface ICategoriesService {

    /// <summary>
    /// Gets Categories from Database and returns it to User Interface.
    /// </summary>
    /// <returns>Collection of Categories</returns>
    Task<IEnumerable<Category>> GetCategoriesAsync();    
  }
}