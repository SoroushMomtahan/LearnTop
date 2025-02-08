using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Identity.Application.Roles.Features.Commands.CreateRole;

public record CreateRoleCommand(string Name) : ICommand<CreateRoleResponse>;
