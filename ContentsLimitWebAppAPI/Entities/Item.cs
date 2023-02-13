namespace ContentsLimitWebAppAPI.Entities {

  /// <summary>
  /// Represents the Item object blueprint.
  /// </summary>
  public class Item {

    /// <summary>
    /// Gets or sets Item ID.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets Item Name.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets Item Value.
    /// </summary>
    public decimal Value { get; set; }

    /// <summary>
    /// Gets or sets Category ID.
    /// </summary>
    public int CategoryId { get; set; }

    /// <summary>
    /// Gets or sets the reference to appropriate Category.
    /// </summary>
    public Category? ItemCategory { get; set; }
  }
}