using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ContentsLimitWebAppAPI.Entities {
  public class Category {
    public int Id { get; set; }
    public string? Name { get; set; }

    [NotMapped]
    [JsonIgnore]
    public virtual ICollection<Item>? CategoryItems { get; set; }
  }
}