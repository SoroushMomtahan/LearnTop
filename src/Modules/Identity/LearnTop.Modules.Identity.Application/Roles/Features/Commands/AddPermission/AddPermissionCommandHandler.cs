using LearnTop.Modules.Identity.Application.Abstractions.Data;
using LearnTop.Modules.Identity.Domain.Roles.Errors;
using LearnTop.Modules.Identity.Domain.Roles.Models;
using LearnTop.Modules.Identity.Domain.Roles.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Identity.Application.Roles.Features.Commands.AddPermission;

internal sealed class AddPermissionCommandHandler(
    IPermissionRepository permissionRepository,
    IRoleRepository roleRepository,
    IUnitOfWork unitOfWork) : 
    ICommandHandler<AddPermissionCommand, AddPermissionResponse>
{

    public async Task<Result<AddPermissionResponse>> Handle(
        AddPermissionCommand request, 
        CancellationToken cancellationToken)
    {
        Permission? permission = await permissionRepository.GetByIdAsync(
            request.PermissionId, cancellationToken);
        if (permission is null)
        {
            return Result.Failure<AddPermissionResponse>(RoleErrors.PermissionNotFound);
        }
        Role role = await roleRepository.GetByIdAsync(request.RoleId, cancellationToken);
        if (role is null)
        {
            return Result.Failure<AddPermissionResponse>(RoleErrors.RoleNotFound);
        }
        Result addPermissionResult = role.AddPermission(permission);
        if (addPermissionResult.IsFailure)
        {
            return Result.Failure<AddPermissionResponse>(addPermissionResult.Error);
        }
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new AddPermissionResponse(permission.Id);
    }
}
