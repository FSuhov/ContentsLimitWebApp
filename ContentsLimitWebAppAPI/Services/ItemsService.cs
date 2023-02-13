using ContentsLimitWebAppAPI.Entities;
using ContentsLimitWebAppAPI.Interfaces;

namespace ContentsLimitWebAppAPI.Services {

  /// <summary>
  /// Contains implementation of business logic for managing the Items.
  /// </summary>
  public class ItemsService : IItemsService {

    private readonly IItemsRepository _itemsRepository;

    /// <summary>
    /// Initializes new instance of IItemsService.
    /// </summary>
    /// <param name="itemsRepository">The instance of Items repository</param>
    public ItemsService(IItemsRepository itemsRepository) { 
      _itemsRepository = itemsRepository;
    }

    /// <summary>
    /// Gets Items from Database and returns it to User Interface.
    /// </summary>
    /// <returns>Collection of Items</returns>
    public async Task<IEnumerable<Item>> GetItemsAsync() {
      return await _itemsRepository.GetItems();
    }

    /// <summary>
    /// Inserts new Item into Database, returns ID of inserted Item.
    /// </summary>
    /// <param name="item">Item object</param>
    /// <returns>Inserted Item ID</returns>
    public async Task<int> InsertItemAsync(Item item) {
      return await _itemsRepository.InsertItem(item);
    }

    /// <summary>
    /// Deletes the Item from Database.
    /// </summary>
    /// <param name="id">Item ID</param>
    public async Task DeleteItemAsync(int id) {
      await _itemsRepository.DeleteItem(id);
    }
  }
}