using LearnTop.Modules.Identity.Application.Abstractions.Data;
using LearnTop.Modules.Identity.Domain.Roles.Models;
using LearnTop.Modules.Identity.Domain.Roles.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Identity.Application.Roles.Features.Commands.CreateRole;

internal sealed class CreateRoleCommandHandler(
    IRoleRepository roleRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<CreateRoleCommand, CreateRoleResponse>
{

    public async Task<Result<CreateRoleResponse>> Handle(
        CreateRoleCommand request, 
        CancellationToken cancellationToken)
    {
        Role role = new(request.Name);
        await roleRepository.CreateAsync(role, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new CreateRoleResponse(role.Id);
    }
}
