using LearnTop.Modules.Identity.Domain.Users.Errors;
using LearnTop.Modules.Identity.Domain.Users.Models;
using LearnTop.Modules.Identity.Domain.Users.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Identity.Application.Users.Features.Queries.GetUserRolePermissions;

internal sealed class GetUserRolePermissionsQueryHandler(
    IUserRepository userRepository) : IQueryHandler<GetUserRolePermissionsQuery, GetUserRolePermissionsResponse>
{

    public async Task<Result<GetUserRolePermissionsResponse>> Handle(GetUserRolePermissionsQuery request, CancellationToken cancellationToken)
    {
        User? user = await userRepository.GetUserAsync(request.UserId, cancellationToken);
        if (user is null)
        {
            return Result.Failure<GetUserRolePermissionsResponse>(UserErrors.NotFound);
        }
        HashSet<string> permissions = await userRepository.GetUserRolePermissionsAsync(user, cancellationToken);
        return new GetUserRolePermissionsResponse(permissions);
    }
}
