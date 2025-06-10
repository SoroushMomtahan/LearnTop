using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Blogs.Application.Snapshots.UserSnapshots.Features.GetUserSnapshotById;

public record GetUserSnapshotByIdQuery(Guid UserId) : IQuery<GetUserSnapshotByIdQuery.Response>
{
    public record Response(UserSnapshot UserSnapshot);
};
