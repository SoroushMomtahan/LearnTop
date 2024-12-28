using LearnTop.Modules.Blogs.Application.Abstractions.Data;
using LearnTop.Modules.Blogs.Domain.Articles.Models;
using LearnTop.Modules.Blogs.Infrastructure.Articles;
using Microsoft.EntityFrameworkCore;

namespace LearnTop.Modules.Blogs.Infrastructure.WriteDb;

public sealed class BlogsDbContext(DbContextOptions<BlogsDbContext> options) : DbContext(options), IUnitOfWork
{
    internal DbSet<Article> Articles => Set<Article>();
    internal DbSet<ArticleTag> Tags => Set<ArticleTag>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder
            .ApplyConfiguration(new ArticleConfiguration())
            .ApplyConfiguration(new ArticleTagConfiguration())
            .HasDefaultSchema(Schemas.Blogs);
    }
}
