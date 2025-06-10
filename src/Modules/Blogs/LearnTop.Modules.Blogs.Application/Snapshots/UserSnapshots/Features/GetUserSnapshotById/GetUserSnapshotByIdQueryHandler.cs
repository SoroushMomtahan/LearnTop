using LearnTop.Modules.Blogs.Application.Snapshots.UserSnapshots.Errors;
using LearnTop.Modules.Blogs.Application.Snapshots.UserSnapshots.Services;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Application.Snapshots.UserSnapshots.Features.GetUserSnapshotById;

internal sealed class GetUserSnapshotByIdQueryHandler(
    IUserSnapshotRepository userSnapshotRepository) : IQueryHandler<GetUserSnapshotByIdQuery, GetUserSnapshotByIdQuery.Response>
{

    public async Task<Result<GetUserSnapshotByIdQuery.Response>> Handle(
        GetUserSnapshotByIdQuery request, 
        CancellationToken cancellationToken)
    {
        UserSnapshot? userSnapshot = await userSnapshotRepository.GetAsync(request.UserId, cancellationToken);
        if (userSnapshot is null)
        {
            return Result.Failure<GetUserSnapshotByIdQuery.Response>(UserSnapshotErrors.NotFound(request.UserId));
        }
        return new GetUserSnapshotByIdQuery.Response(userSnapshot);
    }
}
