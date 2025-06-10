using LearnTop.Modules.Identity.Domain.Users.Models;
using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Identity.Application.Users.Features.Queries.GetUserById;

public record GetUserByIdQuery(Guid UserId) : IQuery<GetUserByIdQuery.Response>
{
    public record Response(User User);
}
