using LearnTop.Modules.Users.PublicApi;

namespace LearnTop.Modules.Users.Infrastructure.PublicApi;

internal sealed class UsersApi
    ()
    : IUsersApi
{

    public Task<bool> IsExist(Guid id)
    {
        return Task.FromResult(true);
    }
}
