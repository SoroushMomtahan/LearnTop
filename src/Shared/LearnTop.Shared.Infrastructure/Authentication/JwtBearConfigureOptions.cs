using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace LearnTop.Shared.Infrastructure.Authentication;

internal sealed class JwtBearConfigureOptions(IConfiguration configuration)
    : IConfigureNamedOptions<JwtBearerOptions>
{
    private const string JwtBearerOptionsSectionName = "Authentication";

    public void Configure(JwtBearerOptions options)
    {
        configuration.GetSection(JwtBearerOptionsSectionName).Bind(options);
    }
    public void Configure(string? name, JwtBearerOptions options)
    {
        Configure(options);
    }
}
