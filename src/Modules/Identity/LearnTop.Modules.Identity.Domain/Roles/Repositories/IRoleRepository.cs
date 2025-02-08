using LearnTop.Modules.Identity.Domain.Roles.Models;

namespace LearnTop.Modules.Identity.Domain.Roles.Repositories;

public interface IRoleRepository
{
    Task CreateAsync(Role role, CancellationToken cancellationToken = default);
    Task<Role?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
