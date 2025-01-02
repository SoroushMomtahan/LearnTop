using LearnTop.Modules.Users.Domain.Users.Models;
using LearnTop.Modules.Users.Domain.Users.Repositories;
using LearnTop.Modules.Users.Infrastructure.WriteDb;

namespace LearnTop.Modules.Users.Infrastructure.Users.Repositories;

public class UserRepository(UsersDbContext usersDbContext) : IUserRepository
{

    public async Task AddAsync(User user, CancellationToken cancellationToken = default)
    {
        await usersDbContext.LearnTopUsers.AddAsync(user, cancellationToken);
    }
}
