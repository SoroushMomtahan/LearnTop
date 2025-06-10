using LearnTop.Modules.Blogs.Application.Snapshots.UserSnapshots.Services;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Application.Snapshots.UserSnapshots.Features.CreateUserSnapshot;

internal sealed class CreateUserSnapshotCommandHandler(
    IUserSnapshotRepository userSnapshotRepository) : ICommandHandler<CreateUserSnapshotCommand>
{

    public async Task<Result> Handle(
        CreateUserSnapshotCommand request, 
        CancellationToken cancellationToken)
    {
        UserSnapshot userSnapshot = new()
        {
            UserId = request.UserId,
            Username = request.Username,
        };
        await userSnapshotRepository.CreateAsync(userSnapshot, cancellationToken);
        await userSnapshotRepository.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
