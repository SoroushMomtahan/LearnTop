using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Identity.Application.Roles.Features.Commands.AddPermission;

public record AddPermissionCommand(Guid RoleId, Guid PermissionId) : 
    ICommand<AddPermissionResponse>;
