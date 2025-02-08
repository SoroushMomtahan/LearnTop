using LearnTop.Modules.Identity.Domain.Roles.Models;
using LearnTop.Modules.Identity.Domain.Roles.Repositories;
using LearnTop.Modules.Identity.Infrastructure.Data.WriteDb;
using Microsoft.EntityFrameworkCore;

namespace LearnTop.Modules.Identity.Infrastructure.Roles.Repositories;

internal sealed class PermissionRepository(
    IdentityDbContext dbContext) : IPermissionRepository
{

    public async Task<Permission?> GetByIdAsync(
        Guid id, 
        CancellationToken cancellationToken = default)
    {
        return await dbContext.Permissions
            .SingleOrDefaultAsync(c => c.Id == id, cancellationToken);
    }
}
