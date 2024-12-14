using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Application.Pagination;

namespace LearnTop.Modules.Users.Application.Users.Queries.GetUsers;

public sealed record GetUsersQuery
    (PaginationRequest PaginationRequest)
    : IQuery<GetUsersQueryResponse>;
