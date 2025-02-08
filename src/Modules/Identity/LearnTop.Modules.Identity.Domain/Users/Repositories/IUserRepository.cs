using LearnTop.Modules.Identity.Domain.Users.Models;

namespace LearnTop.Modules.Identity.Domain.Users.Repositories;

public interface IUserRepository
{
    Task<User?> GetUserAsync(string email, CancellationToken cancellationToken = default);
    Task<User?> GetUserAsync(Guid id, CancellationToken cancellationToken = default);
    Task CreateAsync(User user, CancellationToken cancellationToken = default);
    void Update(User user);
    Task<HashSet<string>> GetUserRolePermissionsAsync(User user, CancellationToken cancellationToken = default);
}
