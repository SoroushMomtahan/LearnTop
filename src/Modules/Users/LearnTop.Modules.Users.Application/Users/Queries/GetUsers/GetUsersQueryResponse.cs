using LearnTop.Modules.Users.Application.Users.Dtos;
using LearnTop.Shared.Application.Pagination;

namespace LearnTop.Modules.Users.Application.Users.Queries.GetUsers;

public sealed record GetUsersQueryResponse(PaginatedResult<UserViewDto> PaginatedResult);
