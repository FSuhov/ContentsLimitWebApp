namespace ContentsLimitWebAppAPI.Entities {
  public class Item {
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Value { get; set; }
    public int CategoryId { get; set; }
    public Category? ItemCategory { get; set; }
  }
}