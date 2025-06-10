using LearnTop.Modules.Blogs.Application.Snapshots.UserSnapshots;
using LearnTop.Modules.Blogs.Infrastructure.UserSnapshots.Configurations;
using Microsoft.EntityFrameworkCore;

namespace LearnTop.Modules.Blogs.Infrastructure.Data.SnapshotsDb;

public class BlogsSnapshotsDbContext(DbContextOptions<BlogsSnapshotsDbContext> options) : DbContext(options)
{
    public DbSet<UserSnapshot> UserSnapshots => Set<UserSnapshot>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema(Schemas.Blogs);
        modelBuilder.ApplyConfiguration(new UserSnapshotConfiguration());
    }
}
