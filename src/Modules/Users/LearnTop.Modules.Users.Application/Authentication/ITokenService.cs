using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace LearnTop.Modules.Users.Application.Authentication;

public interface ITokenService
{
    string GenerateAccessToken(IdentityUser identityUser);
    string GenerateRefreshToken(IdentityUser identityUser);
}
