using Microsoft.EntityFrameworkCore;
using Tagging.Tags.Views;

namespace Tagging.Data.ReadDb;

public class TaggingViewDbContext(DbContextOptions<TaggingViewDbContext> options) : DbContext(options)
{
    public DbSet<TagView> TagViews => Set<TagView>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema(Schemas.Tagging);
    }
}
