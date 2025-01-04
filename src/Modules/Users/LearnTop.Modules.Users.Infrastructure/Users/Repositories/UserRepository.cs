using LearnTop.Modules.Users.Domain.Users.Models;
using LearnTop.Modules.Users.Domain.Users.Repositories;
using LearnTop.Modules.Users.Infrastructure.WriteDb;
using Microsoft.EntityFrameworkCore;

namespace LearnTop.Modules.Users.Infrastructure.Users.Repositories;

public class UserRepository(UsersDbContext usersDbContext) : IUserRepository
{

    public async Task AddAsync(User user, CancellationToken cancellationToken = default)
    {
        await usersDbContext.LearnTopUsers.AddAsync(user, cancellationToken);
    }
    public async Task<User?> GetByIdentityAsync(Guid id, CancellationToken cancellationToken = default)
    {
        User? user = await usersDbContext.LearnTopUsers
            .FirstOrDefaultAsync(x => x.IdentityUser == id, cancellationToken);
        return user;
    }
}
