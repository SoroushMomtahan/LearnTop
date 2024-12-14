using LearnTop.Modules.Users.Domain.Users.Repositories;
using LearnTop.Modules.Users.Domain.Users.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace LearnTop.Modules.Users.Infrastructure.Database.ReadDb.Repository;

public class UserViewRepository
    (UsersViewDbContext dbContext)
    : IUserViewRepository
{

    public async Task<UserView> GetAsync(Guid userId)
    {
        return await dbContext.UserViews.AsNoTracking().FirstOrDefaultAsync(u => u.Id == userId);
    }
    public Task<List<UserView>> GetAllAsync(int pageIndex, int pageSize)
    {
        return dbContext.UserViews
            .AsNoTracking()
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }
    public async Task<int> GetCountAsync()
    {
        return await dbContext.UserViews.CountAsync();
    }
    public async Task AddAsync(UserView userView)
    {
        await dbContext.UserViews.AddAsync(userView);
    }
    public void Update(UserView userView)
    {
        dbContext.UserViews.Update(userView);
    }
    public async Task Delete(Guid userId)
    {
        UserView userView = await GetAsync(userId);
        dbContext.UserViews.Remove(userView);
    }
    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}
