using ContentsLimitWebAppAPI.Entities;
using ContentsLimitWebAppAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContentsLimitWebAppAPI.DataAccess.Repositories {

  /// <summary>
  /// Represents the object containing Data access methods for managing the Categories in Database.
  /// </summary>
  public class CategoriesRepository : ICategoriesRepository {

    private readonly DataContext _dataContext;

    /// <summary>
    /// Initializes new instance of CategoriesRepository.
    /// </summary>
    /// <param name="dataContext">Instance of DataContext</param>
    public CategoriesRepository(DataContext dataContext) {
      _dataContext = dataContext;
    }

    /// <summary>
    /// Selects all Categories from Database.
    /// </summary>
    /// <returns>Collection of Categories records</returns>
    public async Task<IEnumerable<Category>> GetCategories() {
      return await _dataContext.Categories.ToArrayAsync();
    }    
  }
}