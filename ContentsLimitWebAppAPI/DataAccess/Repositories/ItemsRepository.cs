using ContentsLimitWebAppAPI.Entities;
using ContentsLimitWebAppAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContentsLimitWebAppAPI.DataAccess.Repositories {

  /// <summary>
  /// Represents the object containing Data access methods for managing the Items in Database.
  /// </summary>
  public class ItemsRepository : IItemsRepository {

    private readonly DataContext _dataContext;

    /// <summary>
    /// Initializes new instance of ItemsRepository.
    /// </summary>
    /// <param name="dataContext">Instance of DataContext</param>
    public ItemsRepository(DataContext dataContext) {
      _dataContext = dataContext;
    }

    /// <summary>
    /// Selects all Items from Database.
    /// </summary>
    /// <returns>Collection of Items records</returns>
    public async Task<IEnumerable<Item>> GetItems() {
      return await _dataContext.Items.ToArrayAsync();
    }

    /// <summary>
    /// Insrerts new record of Item to Database.
    /// </summary>
    /// <param name="item">Item object</param>
    /// <returns>Id of inserted item</returns>
    public async Task<int> InsertItem(Item item) {
      _dataContext.Items.Add(item);
      await _dataContext.SaveChangesAsync();
      return item.Id;
    }

    /// <summary>
    /// Deletes specified record from Database.
    /// </summary>
    /// <param name="id">Id of Item</param>
    public async Task DeleteItem(int id) {
      var itemTodelete = await _dataContext.Items.FirstOrDefaultAsync(q => q.Id == id);
      if (itemTodelete != null) {
        _dataContext.Items.Remove(itemTodelete);
        await _dataContext.SaveChangesAsync();
      }
    }
  }
}