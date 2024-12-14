using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Users.Application.Users.Queries.GetUser;

public record GetUserQuery(Guid UserId)
    : IQuery<GetUserQueryResponse>;
