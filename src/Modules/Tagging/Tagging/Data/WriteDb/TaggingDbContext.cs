using Microsoft.EntityFrameworkCore;
using Tagging.Tags.Models;

namespace Tagging.Data.WriteDb;

internal sealed class TaggingDbContext(DbContextOptions<TaggingDbContext> options) : DbContext(options)
{
    internal DbSet<Tag> Tags => Set<Tag>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema(Schemas.Tagging);
    }
}
