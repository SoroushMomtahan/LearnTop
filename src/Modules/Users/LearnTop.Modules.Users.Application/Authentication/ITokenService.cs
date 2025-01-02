using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace LearnTop.Modules.Users.Application.Authentication;

public interface ITokenService
{
    string GenerateAccessTokenAsync(IdentityUser identityUser);
    string GenerateRefreshTokenAsync(IdentityUser identityUser);
}
