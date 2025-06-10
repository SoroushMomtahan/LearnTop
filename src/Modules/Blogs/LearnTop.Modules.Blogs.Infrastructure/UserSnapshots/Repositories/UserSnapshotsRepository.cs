using LearnTop.Modules.Blogs.Application.Snapshots.UserSnapshots;
using LearnTop.Modules.Blogs.Application.Snapshots.UserSnapshots.Services;
using LearnTop.Modules.Blogs.Infrastructure.Data.SnapshotsDb;
using Microsoft.EntityFrameworkCore;

namespace LearnTop.Modules.Blogs.Infrastructure.UserSnapshots.Repositories;

public class UserSnapshotsRepository(BlogsSnapshotsDbContext snapshotsDbContext) : IUserSnapshotRepository
{

    public async Task CreateAsync(
        UserSnapshot userSnapshot, 
        CancellationToken cancellationToken = default)
    {
        await snapshotsDbContext.UserSnapshots.AddAsync(userSnapshot, cancellationToken);
    }
    public async Task<UserSnapshot?> GetAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        UserSnapshot userSnapshot = await snapshotsDbContext.UserSnapshots.FirstOrDefaultAsync(
            x=>x.UserId == userId, cancellationToken);
        return userSnapshot;
    }
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await snapshotsDbContext.SaveChangesAsync(cancellationToken);
    }
}
