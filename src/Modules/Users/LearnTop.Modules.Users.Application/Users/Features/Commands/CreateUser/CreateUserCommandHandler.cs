using LearnTop.Modules.Users.Application.Abstractions.Data;
using LearnTop.Modules.Users.Domain.Users.Errors;
using LearnTop.Modules.Users.Domain.Users.Models;
using LearnTop.Modules.Users.Domain.Users.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Application.Exceptions;
using LearnTop.Shared.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LearnTop.Modules.Users.Application.Users.Features.Commands.CreateUser;

public class CreateUserCommandHandler(
    UserManager<IdentityUser> userManager,
    IUserRepository userRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreateUserCommand, CreateUserResponse>
{

    public async Task<Result<CreateUserResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        IdentityUser identityUser = new()
        {
            Email = request.Email,
            UserName = request.Email,
        };
        IdentityUser user = await userManager.FindByEmailAsync(identityUser.Email);
        if (user is not null)
        {
            return Result.Failure<CreateUserResponse>(UserErrors.EmailAlreadyExist);
        }
        IdentityResult identityResult = await userManager.CreateAsync(identityUser, request.Password);
        if (!identityResult.Succeeded)
        {
            Error[] errors = identityResult.Errors.Select(error => Error.Problem(error.Code, error.Description)).ToArray();
            return Result.Failure<CreateUserResponse>(new ValidationError(errors));
        }
        string userId = await userManager.GetUserIdAsync(identityUser);

        Result<User> result = User.Create(Guid.Parse(userId));
        if (result.IsFailure)
        {
            return Result.Failure<CreateUserResponse>(result.Error);
        }
        await userRepository.AddAsync(result.Value, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new CreateUserResponse(Guid.Parse(userId));
    }
}
