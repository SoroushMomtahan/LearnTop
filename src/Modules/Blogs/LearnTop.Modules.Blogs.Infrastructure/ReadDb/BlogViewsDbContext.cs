using LearnTop.Modules.Blogs.Domain.Articles.Models;
using LearnTop.Modules.Blogs.Domain.Articles.ValueObjects;
using LearnTop.Modules.Blogs.Domain.Articles.Views;
using LearnTop.Modules.Blogs.Infrastructure.ArticleViews;
using Microsoft.EntityFrameworkCore;

namespace LearnTop.Modules.Blogs.Infrastructure.ReadDb;

public sealed class BlogViewsDbContext(DbContextOptions<BlogViewsDbContext> options) : DbContext(options)
{
    internal DbSet<ArticleView> ArticleViews => Set<ArticleView>();
    internal DbSet<ArticleTagView> ArticleTagViews => Set<ArticleTagView>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema(Schemas.Blogs)
            .ApplyConfiguration(new ArticleViewConfiguration())
            .ApplyConfiguration(new ArticleTagViewConfiguration());
    }
}
