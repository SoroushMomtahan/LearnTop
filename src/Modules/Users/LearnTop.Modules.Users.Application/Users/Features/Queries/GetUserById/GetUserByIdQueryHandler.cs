using LearnTop.Modules.Users.Domain.Users.Errors;
using LearnTop.Modules.Users.Domain.Users.Models;
using LearnTop.Modules.Users.Domain.Users.Repositories;
using LearnTop.Modules.Users.Domain.Users.ViewModels;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;
using Microsoft.AspNetCore.Identity;

namespace LearnTop.Modules.Users.Application.Users.Features.Queries.GetUserById;

internal sealed class GetUserByIdQueryHandler(
    UserManager<IdentityUser> userManager,
    IUserRepository userRepository)
    : IQueryHandler<GetUserByIdQuery, GetUserByIdResponse>
{

    public async Task<Result<GetUserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        User user = await userRepository.GetByIdentityAsync(request.UserId, cancellationToken);
        if (user is null)
        {
            return Result.Failure<GetUserByIdResponse>(UserErrors.NotFound(request.UserId));
        }
        IdentityUser? identityUser = await userManager.FindByIdAsync(request.UserId.ToString());
        if (identityUser is null)
        {
            return Result.Failure<GetUserByIdResponse>(UserErrors.NotFound(request.UserId));
        }
        UserView userView = new()
        {
            Firstname = user.Firstname,
            Lastname = user.Lastname,
            Email = identityUser.Email!,
        };
        return new GetUserByIdResponse(userView);
    }
}
