using ContentsLimitWebAppAPI.Entities;
using ContentsLimitWebAppAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContentsLimitWebAppAPI.DataAccess.Repositories {
  public class ItemsRepository : IItemsRepository {

    private readonly DataContext _dataContext;
    public ItemsRepository(DataContext dataContext) {
      _dataContext = dataContext;
    }
    public async Task<IEnumerable<Item>> GetItems() {
      return await _dataContext.Items.ToArrayAsync();
    }
    public async Task<int> InsertItem(Item item) {
      _dataContext.Items.Add(item);
      await _dataContext.SaveChangesAsync();
      return item.Id;
    }
    public async Task DeleteItem(int id) {
      var itemTodelete = await _dataContext.Items.FirstOrDefaultAsync(q => q.Id == id);
      if (itemTodelete != null) {
        _dataContext.Items.Remove(itemTodelete);
        await _dataContext.SaveChangesAsync();
      }
    }
  }
}