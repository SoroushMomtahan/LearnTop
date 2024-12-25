using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace LearnTop.Shared.Infrastructure.Authentication;

internal static class AuthenticationExtensions
{
    internal static IServiceCollection AddAuthenticationInternal(this IServiceCollection services)
    {
        services.AddAuthorization();
        services.AddAuthentication().AddJwtBearer();
        services.AddHttpContextAccessor();
        services.ConfigureOptions<JwtBearConfigureOptions>();
        return services;
    }
}
