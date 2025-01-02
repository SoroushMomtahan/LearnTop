using LearnTop.Modules.Users.Application.Abstractions.Data;
using LearnTop.Modules.Users.Domain.Users.Models;
using LearnTop.Modules.Users.Infrastructure.Users.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LearnTop.Modules.Users.Infrastructure.WriteDb;

public class UsersDbContext(DbContextOptions<UsersDbContext> options)
    : IdentityDbContext<IdentityUser>(options), IUnitOfWork
{
    public DbSet<User> LearnTopUsers => Set<User>();
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.HasDefaultSchema("Users");
        builder.ApplyConfiguration(new UserConfiguration());
    }
}
