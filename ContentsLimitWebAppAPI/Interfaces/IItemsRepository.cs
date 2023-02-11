using ContentsLimitWebAppAPI.Entities;

namespace ContentsLimitWebAppAPI.Interfaces {
  public interface IItemsRepository {
    Task<IEnumerable<Item>> GetItems();
    Task<int> InsertItem(Item item);
    Task DeleteItem(int id);
  }
}