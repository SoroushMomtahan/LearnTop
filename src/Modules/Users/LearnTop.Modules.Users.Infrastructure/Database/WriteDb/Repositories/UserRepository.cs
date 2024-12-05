using LearnTop.Modules.Users.Domain.Users.Models;
using LearnTop.Modules.Users.Domain.Users.Repositories;

namespace LearnTop.Modules.Users.Infrastructure.Database.WriteDb.Repositories;

public class UserRepository
    (UsersDbContext dbContext)
    : IUserRepository
{

    public async Task AddAsync(User user)
    {
        await dbContext.Users.AddAsync(user);
    }
}
