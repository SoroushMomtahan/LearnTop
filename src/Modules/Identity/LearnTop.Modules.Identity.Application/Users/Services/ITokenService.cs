using LearnTop.Modules.Identity.Domain.Users.Models;

namespace LearnTop.Modules.Identity.Application.Users.Services;

public interface ITokenService
{
    string GenerateAccessToken(User user);
    string GenerateRefreshToken(User user);
}

