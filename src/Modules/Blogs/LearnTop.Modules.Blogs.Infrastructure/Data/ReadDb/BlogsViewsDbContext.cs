using LearnTop.Modules.Blogs.Application.Articles.Views;
using LearnTop.Modules.Blogs.Application.Authors.Views;
using Microsoft.EntityFrameworkCore;

namespace LearnTop.Modules.Blogs.Infrastructure.Data.ReadDb;

public sealed class BlogsViewsDbContext(DbContextOptions<BlogsViewsDbContext> options) : DbContext(options)
{
    internal DbSet<ArticleView> ArticleViews => Set<ArticleView>();
    internal DbSet<AuthorView> AuthorViews => Set<AuthorView>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema(Schemas.Blogs);
    }
}
