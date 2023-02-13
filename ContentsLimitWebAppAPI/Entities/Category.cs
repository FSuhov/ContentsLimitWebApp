using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ContentsLimitWebAppAPI.Entities {

  /// <summary>
  /// Represents the Category object blueprint.
  /// </summary>
  public class Category {

    /// <summary>
    /// Gets or sets Category ID.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets Category NAME.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets Category Items.
    /// </summary>
    [NotMapped]
    [JsonIgnore]
    public virtual ICollection<Item>? CategoryItems { get; set; }
  }
}