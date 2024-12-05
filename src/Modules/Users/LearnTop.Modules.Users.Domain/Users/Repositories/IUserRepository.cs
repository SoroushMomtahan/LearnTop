using LearnTop.Modules.Users.Domain.Users.Models;

namespace LearnTop.Modules.Users.Domain.Users.Repositories;

public interface IUserRepository
{
    Task AddAsync(User user);
}
