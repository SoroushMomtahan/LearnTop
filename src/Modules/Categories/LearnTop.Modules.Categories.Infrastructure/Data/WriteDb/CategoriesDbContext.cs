using LearnTop.Modules.Categories.Application.Abstractions.Data;
using LearnTop.Modules.Categories.Domain.Categories.Models;
using LearnTop.Modules.Categories.Infrastructure.Categories.Configurations;
using Microsoft.EntityFrameworkCore;

namespace LearnTop.Modules.Categories.Infrastructure.Data.WriteDb;

public class CategoriesDbContext(
    DbContextOptions<CategoriesDbContext> options)
    : DbContext(options), IUnitOfWork
{
    internal DbSet<Category> Categories => Set<Category>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema(Schemas.Categories);
        modelBuilder.ApplyConfiguration(new CategoryRelationConfiguration());
    }
}
