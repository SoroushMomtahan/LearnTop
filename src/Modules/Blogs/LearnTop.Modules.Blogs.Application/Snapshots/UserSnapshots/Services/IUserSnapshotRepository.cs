namespace LearnTop.Modules.Blogs.Application.Snapshots.UserSnapshots.Services;

public interface IUserSnapshotRepository
{
    Task CreateAsync(UserSnapshot userSnapshot, CancellationToken cancellationToken = default);
    Task<UserSnapshot?> GetAsync(Guid userId, CancellationToken cancellationToken = default);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
