using ContentsLimitWebAppAPI.Entities;
using ContentsLimitWebAppAPI.Interfaces;
using ContentsLimitWebAppAPI.Services;
using Moq;

namespace ContentsLimitWebAppAPITests {
  public class ItemsServiceTests {

    private readonly Mock<IItemsRepository> _itemsRepository;

    public ItemsServiceTests() {
      _itemsRepository = new Mock<IItemsRepository>();
      _itemsRepository.Setup(q => q.GetItems()).ReturnsAsync(items);      
    }

    [Fact]
    public async Task Should_Return_Expected_Items() {
      // Arrange
      var service = new ItemsService(_itemsRepository.Object);

      // Act
      var result = await service.GetItemsAsync();

      // Assert
      Assert.NotNull(result);
      Assert.Equal(items.Count, result.ToList().Count);
      Assert.Equal(items.First().Name, result.ToList().First().Name);
      _itemsRepository.Verify(q => q.GetItems(), Times.Once);
    }

    [Fact]
    public async Task Should_Return_Id_When_Insert_Item() {
      // Arrange
      var itemToInsert = new Item { CategoryId = 1, Name = "IPhone", Value = 750.50m };
      var insertedId = 99;
      _itemsRepository.Setup(q => q.InsertItem(It.Is<Item>(i => i == itemToInsert))).ReturnsAsync(insertedId);
      var service = new ItemsService(_itemsRepository.Object);

      // Act
      var result = await service.InsertItemAsync(itemToInsert);

      // Assert
      Assert.Equal(insertedId, result);
      _itemsRepository.Verify(q => q.InsertItem(It.IsAny<Item>()), Times.Once);
      _itemsRepository.Verify(q => q.GetItems(), Times.Never);
    }

    public static List<Item> items => new List<Item> {
      new Item { Id = 1, CategoryId = 1, Name = "IPhone", Value = 750.50m },
      new Item { Id = 2, CategoryId = 1, Name = "Camera", Value = 990.00m },
      new Item { Id = 3, CategoryId = 2, Name = "Shirt", Value = 44.00m }
    };
  }
}