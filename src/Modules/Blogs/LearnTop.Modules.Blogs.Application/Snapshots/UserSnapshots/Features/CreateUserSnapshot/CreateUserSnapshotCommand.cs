using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Blogs.Application.Snapshots.UserSnapshots.Features.CreateUserSnapshot;

public record CreateUserSnapshotCommand(
    Guid UserId,
    string Username) : ICommand;
