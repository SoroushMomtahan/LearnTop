using LearnTop.Modules.Users.Domain.Users.ViewModels;

namespace LearnTop.Modules.Users.Domain.Users.Repositories;

public interface IUserViewRepository
{
    Task<UserView> GetAsync(Guid userId);
    Task<List<UserView>> GetAllAsync(int pageIndex, int pageSize);
    Task<int> GetCountAsync();
    Task AddAsync(UserView userView);
    void Update(UserView userView);
    Task Delete(Guid userId);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
