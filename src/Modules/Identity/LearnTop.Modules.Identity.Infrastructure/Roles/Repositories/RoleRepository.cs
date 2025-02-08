using LearnTop.Modules.Identity.Domain.Roles.Models;
using LearnTop.Modules.Identity.Domain.Roles.Repositories;
using LearnTop.Modules.Identity.Infrastructure.Data.WriteDb;
using Microsoft.EntityFrameworkCore;

namespace LearnTop.Modules.Identity.Infrastructure.Roles.Repositories;

internal sealed class RoleRepository(IdentityDbContext dbContext) : IRoleRepository
{

    public async Task CreateAsync(Role role, CancellationToken cancellationToken = default)
    {
        await dbContext.Roles.AddAsync(role, cancellationToken);
    }
    public async Task<Role?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await dbContext.Roles
            .SingleOrDefaultAsync(r => r.Id == id, cancellationToken);
    }
}
