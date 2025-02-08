using LearnTop.Modules.Identity.Domain.Roles.Models;

namespace LearnTop.Modules.Identity.Domain.Roles.Repositories;

public interface IPermissionRepository
{
    Task<Permission?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
