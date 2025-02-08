using LearnTop.Modules.Identity.Application.Abstractions.Data;
using LearnTop.Modules.Identity.Application.Users.Services;
using LearnTop.Modules.Identity.Domain.Users.Errors;
using LearnTop.Modules.Identity.Domain.Users.Models;
using LearnTop.Modules.Identity.Domain.Users.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Identity.Application.Users.Features.Commands.SignInWithEmail;

internal sealed class SignInWithEmailCommandHandler(
    IUserRepository userRepository,
    IUnitOfWork unitOfWork,
    IPasswordHasher passwordHasher,
    ITokenService tokenService) : ICommandHandler<SignInWithEmailCommand, SignInWithEmailResponse>
{

    public async Task<Result<SignInWithEmailResponse>> Handle(
        SignInWithEmailCommand request,
        CancellationToken cancellationToken)
    {
        User? user = await userRepository.GetUserAsync(request.Email, cancellationToken);
        if (user is null)
        {
            return Result.Failure<SignInWithEmailResponse>(UserErrors.NotFound);
        }
        if (!user.Email.Verify.Status)
        {
            return Result.Failure<SignInWithEmailResponse>(UserErrors.NotVerified);
        }
        bool result = passwordHasher.Verify(request.Password, user.PasswordHash);
        if (!result)
        {
            return Result.Failure<SignInWithEmailResponse>(UserErrors.NotFound);
        }
        string accessToken = tokenService.GenerateAccessToken(user);
        user.SetRefreshToken(Guid.NewGuid());
        string refreshToken = tokenService.GenerateRefreshToken(user);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new SignInWithEmailResponse(accessToken, refreshToken);
    }
}
