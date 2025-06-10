using LearnTop.Modules.Blogs.Application.Views.ArticleViews;
using LearnTop.Modules.Blogs.Infrastructure.ArticleViews.Configurations;
using Microsoft.EntityFrameworkCore;

namespace LearnTop.Modules.Blogs.Infrastructure.Data.ReadDb;

public sealed class BlogsViewsDbContext(DbContextOptions<BlogsViewsDbContext> options) : DbContext(options)
{
    internal DbSet<ArticleView> ArticleViews => Set<ArticleView>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema(Schemas.Blogs);
        modelBuilder.ApplyConfiguration(new ArticleViewConfiguration());
    }
}
