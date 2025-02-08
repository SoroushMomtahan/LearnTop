using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Identity.Application.Users.Features.Queries.GetUserRolePermissions;

public record GetUserRolePermissionsQuery(Guid UserId) : IQuery<GetUserRolePermissionsResponse>;
