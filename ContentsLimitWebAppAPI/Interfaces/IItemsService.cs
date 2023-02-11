using ContentsLimitWebAppAPI.Entities;

namespace ContentsLimitWebAppAPI.Interfaces {
  public interface IItemsService {
    Task<IEnumerable<Item>> GetItemsAsync();
    Task<int> InsertItemAsync(Item item);
    Task DeleteItemAsync(int id);
  }
}