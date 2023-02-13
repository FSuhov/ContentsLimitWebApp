using ContentsLimitWebAppAPI.Entities;

namespace ContentsLimitWebAppAPI.Interfaces {

  /// <summary>
  /// Contains definitions of business logic methods for Items Service.
  /// </summary>
  public interface IItemsService {

    /// <summary>
    /// Gets Items from Database and returns it to User Interface.
    /// </summary>
    /// <returns>Collection of Items</returns>
    Task<IEnumerable<Item>> GetItemsAsync();

    /// <summary>
    /// Inserts new Item into Database, returns ID of inserted Item.
    /// </summary>
    /// <param name="item">Item object</param>
    /// <returns>Inserted Item ID</returns>
    Task<int> InsertItemAsync(Item item);

    /// <summary>
    /// Deletes the Item from Database.
    /// </summary>
    /// <param name="id">Item ID</param>
    Task DeleteItemAsync(int id);
  }
}