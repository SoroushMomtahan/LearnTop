using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Users.Application.Users.Features.Queries.GetUserById;

public record GetUserByIdQuery(Guid UserId) : IQuery<GetUserByIdResponse>;
