using LearnTop.Modules.Identity.Application.Users.Features.Queries.GetUserRolePermissions;
using LearnTop.Shared.Application.Authorization;
using LearnTop.Shared.Application.Caching;
using LearnTop.Shared.Application.Exceptions;
using LearnTop.Shared.Domain;
using ISender = MediatR.ISender;

namespace LearnTop.Modules.Identity.Infrastructure.Authorization;

public class PermissionService(ISender sender, ICacheService cacheService) : IPermissionService
{

    public async Task<HashSet<string>> GetPermissionsAsync(Guid memberId)
    {
        HashSet<string> permissions = await cacheService.GetAsync<HashSet<string>>("Permissions:GetPermissions:" + memberId);
        if (permissions is not null)
        {
            return permissions;
        }
        Result<GetUserRolePermissionsResponse> result = await sender.Send(new GetUserRolePermissionsQuery(memberId));
        if (result.IsFailure)
        {
            throw new LearnTopException(nameof(PermissionService), result.Error);
        }
        await cacheService.SetAsync("Permissions:GetPermissions:" + memberId, result.Value.Permissions);
        return result.Value.Permissions;
    }
}
