using LearnTop.Modules.Blogs.Application.Abstractions.Data;
using LearnTop.Modules.Blogs.Domain.Aggregates.Articles.Models;
using LearnTop.Modules.Blogs.Domain.Aggregates.Authors.Models;
using LearnTop.Modules.Blogs.Domain.Lookups.Categories.Models;
using LearnTop.Modules.Blogs.Domain.Lookups.Tags.Models;
using LearnTop.Modules.Blogs.Infrastructure.Articles;
using LearnTop.Modules.Blogs.Infrastructure.Articles.Configurations;
using Microsoft.EntityFrameworkCore;

namespace LearnTop.Modules.Blogs.Infrastructure.Data.WriteDb;

public sealed class BlogsDbContext(DbContextOptions<BlogsDbContext> options) 
    : DbContext(options), IUnitOfWork
{
    internal DbSet<Article> Articles => Set<Article>();
    internal DbSet<Author> Authors => Set<Author>();
    internal DbSet<Category> Categories => Set<Category>();
    internal DbSet<Tag> Tags => Set<Tag>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder
            .ApplyConfiguration(new ArticleConfiguration())
            .HasDefaultSchema(Schemas.Blogs);
    }
}
