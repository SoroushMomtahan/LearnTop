using LearnTop.Modules.Users.Domain.Users.Repositories;
using LearnTop.Modules.Users.Infrastructure.Database.WriteDb;
using LearnTop.Modules.Users.Infrastructure.Database.WriteDb.Repositories;
using LearnTop.Modules.Users.Presentation;
using LearnTop.Shared.Application.Data;
using LearnTop.Shared.Infrastructure.Interceptors;
using LearnTop.Shared.Presentation.Endpoints;
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
        return services;
    }
    private static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<UsersDbContext>());
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddDbContext<UsersDbContext>((sp, options) =>
        {
            string connectionString = configuration.GetConnectionString("WriteDb");
            options
                .UseSqlServer(connectionString)
                .AddInterceptors(sp.GetRequiredService<PublishDomainEventsInterceptor>());
        });
        return services;
    }
}
