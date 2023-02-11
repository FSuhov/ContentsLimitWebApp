using ContentsLimitWebAppAPI.Entities;
using ContentsLimitWebAppAPI.Interfaces;

namespace ContentsLimitWebAppAPI.Services {
  public class ItemsService : IItemsService {

    private readonly IItemsRepository _itemsRepository;
    public ItemsService(IItemsRepository itemsRepository) { 
      _itemsRepository = itemsRepository;
    }
    public async Task<IEnumerable<Item>> GetItemsAsync() {
      return await _itemsRepository.GetItems();
    }

    public async Task<int> InsertItemAsync(Item item) {
      return await _itemsRepository.InsertItem(item);
    }

    public async Task DeleteItemAsync(int id) {
      await _itemsRepository.DeleteItem(id);
    }
  }
}