using LearnTop.Modules.Users.Application.Abstractions.Data;
using LearnTop.Modules.Users.Domain.Users.Models;
using Microsoft.EntityFrameworkCore;

namespace LearnTop.Modules.Users.Infrastructure.Database.WriteDb;

public class UsersDbContext(DbContextOptions<UsersDbContext> options)
    : DbContext(options), IUnitOfWork
{
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Users");
        base.OnModelCreating(modelBuilder);
    }
}
