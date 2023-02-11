using ContentsLimitWebAppAPI.Entities;
using ContentsLimitWebAppAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContentsLimitWebAppAPI.DataAccess.Repositories {
  public class CategoriesRepository : ICategoriesRepository {

    private readonly DataContext _dataContext;
    public CategoriesRepository(DataContext dataContext) {
      _dataContext = dataContext;
    }      
    public async Task<IEnumerable<Category>> GetCategories() {
      return await _dataContext.Categories.ToArrayAsync();
    }
    public async Task<int> InsertCategory(Category category) {
      _dataContext.Categories.Add(category);
      await _dataContext.SaveChangesAsync();
      return category.Id;
    }
    public async Task DeleteCategory(int id) {
      var categoryTodelete = await _dataContext.Categories.FirstOrDefaultAsync(q => q.Id == id);
      if (categoryTodelete != null) {
        _dataContext.Categories.Remove(categoryTodelete);
        await _dataContext.SaveChangesAsync();
      }
    }
  }
}