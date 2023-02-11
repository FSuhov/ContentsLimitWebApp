using ContentsLimitWebAppAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContentsLimitWebAppAPI.DataAccess {
  public class DataContext : DbContext {
    public DataContext(DbContextOptions options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder builder) {
      base.OnModelCreating(builder);

      builder.Entity<Item>()
        .HasOne(i => i.ItemCategory)
        .WithMany(c => c.CategoryItems)
        .HasForeignKey(i => i.CategoryId)
        .OnDelete(DeleteBehavior.Cascade);
    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Item> Items { get; set; }
  }
}