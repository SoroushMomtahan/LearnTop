using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LearnTop.Modules.Identity.Application.Users.Services;
using LearnTop.Modules.Identity.Domain.Users.Models;
using LearnTop.Shared.Infrastructure.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace LearnTop.Modules.Identity.Infrastructure.Users.Services;

internal sealed class TokenService(IOptions<JwtOptions> options) : ITokenService
{

    public string GenerateAccessToken(User user)
    {
        Claim[] claims =
        [
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email.Address),
        ];

        SigningCredentials signingCredentials = new(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.Secret)),
            SecurityAlgorithms.HmacSha256
            );
        JwtSecurityToken token = new(
            options.Value.Issuer,
            options.Value.Audience,
            claims,
            null,
            DateTime.Now.AddMinutes(options.Value.AccessTokenExpireTimeByMin),
            signingCredentials
            );
        string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        return tokenString;
    }
    public string GenerateRefreshToken(User user)
    {
        Claim[] claims =
        [
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Iat, user.RefreshToken.ToString()),
        ];

        SigningCredentials signingCredentials = new(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.Secret)),
            SecurityAlgorithms.HmacSha256
            );
        JwtSecurityToken token = new(
            options.Value.Issuer,
            options.Value.Audience,
            claims,
            null,
            DateTime.Now.AddMinutes(options.Value.RefreshTokenExpireTimeByMin),
            signingCredentials
            );
        string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        return tokenString;
    }
}
