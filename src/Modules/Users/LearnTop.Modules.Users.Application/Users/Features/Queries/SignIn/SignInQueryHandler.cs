using LearnTop.Modules.Users.Application.Authentication;
using LearnTop.Modules.Users.Domain.Users.Errors;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Application.Exceptions;
using LearnTop.Shared.Domain;
using Microsoft.AspNetCore.Identity;

namespace LearnTop.Modules.Users.Application.Users.Features.Queries.SignIn;

internal sealed class SignInQueryHandler(
    SignInManager<IdentityUser> signInManager,
    UserManager<IdentityUser> userManager,
    ITokenService tokenService)
    : IQueryHandler<SignInQuery, SignInResponse>
{

    public async Task<Result<SignInResponse>> Handle(
        SignInQuery request, 
        CancellationToken cancellationToken)
    {
        IdentityUser identityUser = await userManager.FindByEmailAsync(request.Email);
        if (identityUser is null)
        {
            return Result.Failure<SignInResponse>(
                UserErrors.EmailNotFound(request.Email)
                );
        }
        
        SignInResult signInResult = await signInManager.PasswordSignInAsync(
            identityUser, 
            request.Password, 
            false, 
            true);
        if (!signInResult.Succeeded)
        {
            throw new LearnTopException(nameof(SignInQueryHandler));
        }
        string accessToken = tokenService.GenerateAccessTokenAsync(identityUser);
        string refreshToken = tokenService.GenerateRefreshTokenAsync(identityUser);
        
        return new SignInResponse(accessToken, refreshToken);
    }
}
