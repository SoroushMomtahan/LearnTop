using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LearnTop.Modules.Users.Application.Authentication;
using LearnTop.Shared.Infrastructure.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace LearnTop.Modules.Users.Infrastructure.Authentication;

internal sealed class TokenService(IOptions<JwtOptions> options) : ITokenService
{
    private JwtOptions Options { get; } = options.Value;

    public string GenerateAccessTokenAsync(IdentityUser identityUser)
    {
        Claim[] claims =
        [
            new(JwtRegisteredClaimNames.Sub, identityUser.Id),
            new(JwtRegisteredClaimNames.Email, identityUser.Email!),
        ];

        SigningCredentials signingCredentials = new(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Options.Secret)),
            SecurityAlgorithms.HmacSha256
            );
        JwtSecurityToken token = new(
            Options.Issuer,
            Options.Audience,
            claims,
            null,
            DateTime.Now.AddMinutes(Options.AccessTokenExpireTimeByMin),
            signingCredentials
            );
        string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        return tokenString;
    }
    public string GenerateRefreshTokenAsync(IdentityUser identityUser)
    {
        Claim[] claims =
        [
            new(JwtRegisteredClaimNames.Sub, identityUser.Id),
        ];

        SigningCredentials signingCredentials = new(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Options.Secret)),
            SecurityAlgorithms.HmacSha256
            );
        JwtSecurityToken token = new(
            Options.Issuer,
            Options.Audience,
            claims,
            null,
            DateTime.Now.AddMinutes(Options.AccessTokenExpireTimeByMin),
            signingCredentials
            );
        string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        return tokenString;
    }
}
