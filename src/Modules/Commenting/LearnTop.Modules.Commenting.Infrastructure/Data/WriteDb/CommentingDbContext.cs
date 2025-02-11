using LearnTop.Modules.Commenting.Application.Abstractions.Data;
using LearnTop.Modules.Commenting.Domain.Comments.Models;
using LearnTop.Modules.Commenting.Infrastructure.Comments.Configurations;
using Microsoft.EntityFrameworkCore;

namespace LearnTop.Modules.Commenting.Infrastructure.Data.WriteDb;

public class CommentingDbContext(
    DbContextOptions<CommentingDbContext> options) : DbContext(options), IUnitOfWork
{
    internal DbSet<Comment> Comments => Set<Comment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema(Schemas.Commenting);
        modelBuilder.ApplyConfiguration(new CommentConfiguration());
    }
}
