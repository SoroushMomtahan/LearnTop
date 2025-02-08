using LearnTop.Modules.Identity.Domain.Roles.Models;
using LearnTop.Modules.Identity.Domain.Users.Models;
using LearnTop.Modules.Identity.Domain.Users.Repositories;
using LearnTop.Modules.Identity.Infrastructure.Data.WriteDb;
using Microsoft.EntityFrameworkCore;

namespace LearnTop.Modules.Identity.Infrastructure.Users.Repositories;

public class UserRepository(IdentityDbContext identityDbContext) : IUserRepository
{

    public async Task<User?> GetUserAsync(string email, CancellationToken cancellationToken = default)
    {
        return await identityDbContext.Users
            .Include(x=>x.Email)
            .SingleOrDefaultAsync(x=>x.Email.Address == email, cancellationToken);
    }
    public async Task<User?> GetUserAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await identityDbContext.Users
            .Include(x=>x.Email)
            .SingleOrDefaultAsync(x=>x.Id == id, cancellationToken);
    }
    public async Task CreateAsync(User user, CancellationToken cancellationToken = default)
    {
        await identityDbContext.Users.AddAsync(user, cancellationToken);
    }
    public void Update(User user)
    {
        identityDbContext.Users.Update(user);
    }
    public async Task<HashSet<string>> GetUserRolePermissionsAsync(User user, CancellationToken cancellationToken = default)
    {
        IReadOnlyList<Role>[] roles = await identityDbContext.Set<User>()
            .Include(x => x.Roles)
            .ThenInclude(x => x.Permissions)
            .Where(x => x.Id == user.Id)
            .Select(x => x.Roles)
            .ToArrayAsync(cancellationToken: cancellationToken);

        return roles
            .SelectMany(x => x)
            .SelectMany(x => x.Permissions)
            .Select(x => $"{x.Application}:{x.Type}")
            .ToHashSet();
    }
}
