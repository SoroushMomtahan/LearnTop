using LearnTop.Modules.Users.Domain.Users.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LearnTop.Modules.Users.Infrastructure.Database.ReadDb;

public class UsersViewDbContext(DbContextOptions<UsersViewDbContext> options)
    : DbContext(options)
{
    public DbSet<UserView> UserViews { get; set; }
}
