using LearnTop.Modules.Users.Domain.Users.Models;
using LearnTop.Modules.Users.Infrastructure.Database.WriteDb;
using LearnTop.Modules.Users.PublicApi;

namespace LearnTop.Modules.Users.Infrastructure.PublicApi;

internal sealed class UsersApi
    (UsersDbContext dbContext)
    : IUsersApi
{

    public async Task<bool> IsExist(Guid id)
    {
        User? user = await dbContext.Users.FindAsync(id);
        return user != null;
    }
}
