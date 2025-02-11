using LearnTop.Modules.Identity.Application.Abstractions.Data;
using LearnTop.Modules.Identity.Application.Users.Services;
using LearnTop.Modules.Identity.Domain.Roles.Repositories;
using LearnTop.Modules.Identity.Domain.Users.Repositories;
using LearnTop.Modules.Identity.Infrastructure.Authorization;
using LearnTop.Modules.Identity.Infrastructure.Data.WriteDb;
using LearnTop.Modules.Identity.Infrastructure.PublicApi;
using LearnTop.Modules.Identity.Infrastructure.Roles.Repositories;
using LearnTop.Modules.Identity.Infrastructure.Users.Repositories;
using LearnTop.Modules.Identity.Infrastructure.Users.Services;
using LearnTop.Modules.Identity.Presentation;
using LearnTop.Modules.Identity.PublicApi;
using LearnTop.Shared.Application.Authorization;
using LearnTop.Shared.Infrastructure.Authorization;
using LearnTop.Shared.Infrastructure.Interceptors;
using LearnTop.Shared.Presentation.Endpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LearnTop.Modules.Identity.Infrastructure;

public static class IdentityModule
{
    public static IServiceCollection AddIdentityModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfrastructure(configuration);
        services.AddEndpoints(AssemblyReference.IdentityEndpointAssembly);
        return services;
    }
    private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddWriteDb(configuration);
        services.AddEmailService(configuration);
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IPermissionService, PermissionService>();
        services.AddScoped<IUserApi, UserApi>();
    }
    private static void AddWriteDb(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IdentityDbContext>((sp, options) =>
        {
            options.UseSqlServer(configuration.GetConnectionString("WriteDb"))
                .AddInterceptors(sp.GetRequiredService<PublishDomainEventsInterceptor>());
        });
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IPermissionRepository, PermissionRepository>();
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<IdentityDbContext>());
    }
    private static void AddEmailService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IEmailService, EmailService>();
        services
            .AddFluentEmail(configuration["Email:SenderEmail"], configuration["Email:Sender"])
            .AddSmtpSender(configuration["Email:Host"], configuration.GetValue<int>("Email:Port"));
    }
}
