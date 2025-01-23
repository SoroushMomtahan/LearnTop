using LearnTop.Modules.Users.Application.Abstractions.Data;
using LearnTop.Modules.Users.Application.Authentication;
using LearnTop.Modules.Users.Domain.Users.Repositories;
using LearnTop.Modules.Users.Infrastructure.Authentication;
using LearnTop.Modules.Users.Infrastructure.PublicApi;
using LearnTop.Modules.Users.Infrastructure.Users.Repositories;
using LearnTop.Modules.Users.Infrastructure.WriteDb;
using LearnTop.Modules.Users.Presentation;
using LearnTop.Modules.Users.PublicApi;
using LearnTop.Shared.Infrastructure.Interceptors;
using LearnTop.Shared.Presentation.Endpoints;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LearnTop.Modules.Users.Infrastructure;

public static class UsersModule
{
    public static IServiceCollection AddUsersModule
    (this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddInfrastructure(configuration);
        services.AddEndpoints(AssemblyReference.UsersEndpointAssembly);
        services.AddAuthorizationBuilder()
            .AddPolicy("User", policy =>
            {
                policy.RequireAuthenticatedUser();
            });
        return services;
    }
    private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUsersApi, UsersApi>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddIdentityInfrastructure();
        services.AddWriteDb(configuration);
    }
    private static void AddIdentityInfrastructure(this IServiceCollection services)
    {
        
        
        services.AddIdentityApiEndpoints<IdentityUser>()
            .AddEntityFrameworkStores<UsersDbContext>()
            .AddDefaultTokenProviders();
        
        services.Configure<DataProtectionTokenProviderOptions>(options =>
        {
            options.TokenLifespan = TimeSpan.FromMinutes(10); // Set the email token lifespan to 3 hours
        });

    }
    private static void AddWriteDb(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUnitOfWork>(sp=>sp.GetRequiredService<UsersDbContext>());
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddDbContext<UsersDbContext>((sp, options) =>
        {
            string connectionString = configuration.GetConnectionString("WriteDb");
            options
                .UseSqlServer(connectionString)
                .AddInterceptors(sp.GetRequiredService<PublishDomainEventsInterceptor>());
        });
    }
}
