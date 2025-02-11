using LearnTop.Modules.Identity.Domain.Users.Models;
using LearnTop.Modules.Identity.Infrastructure.Data.WriteDb;
using LearnTop.Modules.Identity.PublicApi;
using Microsoft.EntityFrameworkCore;

namespace LearnTop.Modules.Identity.Infrastructure.PublicApi;

internal sealed class UserApi(IdentityDbContext identityDbContext) : IUserApi
{

    public async Task<GetUserResponse?> GetAsync(Guid userId)
    {
        User? user = await identityDbContext.Users
            .Include(user => user.Email)
            .Include(user => user.Mobile)
            .FirstOrDefaultAsync(u => u.Id == userId);

        if (user is null)
        {
            return null;
        }
        
        GetUserResponse userResponse = new(
            user.Id,
            user.Username,
            user.Email?.Address,
            user.Mobile?.Number,
            user.IsBlocked
            );
        return userResponse;
    }
}
