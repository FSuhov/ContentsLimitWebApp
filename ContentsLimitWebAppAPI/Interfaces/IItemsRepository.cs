using ContentsLimitWebAppAPI.Entities;

namespace ContentsLimitWebAppAPI.Interfaces {

  /// <summary>
  /// Defines data access methods for managing the Items in Database.
  /// </summary>
  public interface IItemsRepository {

    /// <summary>
    /// Gets records of Items from Database.
    /// </summary>
    /// <returns>Collection of Items</returns>
    Task<IEnumerable<Item>> GetItems();

    /// <summary>
    /// Inserts the record for new Item to Database.
    /// </summary>
    /// <param name="item">Item object</param>
    /// <returns>Id of inserted Item</returns>
    Task<int> InsertItem(Item item);

    /// <summary>
    /// Deletes Item record from Database.
    /// </summary>
    /// <param name="id">Id of Item</param>
    Task DeleteItem(int id);
  }
}