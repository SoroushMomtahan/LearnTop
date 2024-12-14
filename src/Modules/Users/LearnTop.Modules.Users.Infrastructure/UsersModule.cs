using LearnTop.Modules.Users.Application.Abstractions.Data;
using LearnTop.Modules.Users.Domain.Users.Repositories;
using LearnTop.Modules.Users.Infrastructure.Database.ReadDb;
using LearnTop.Modules.Users.Infrastructure.Database.ReadDb.Repository;
using LearnTop.Modules.Users.Infrastructure.Database.WriteDb;
using LearnTop.Modules.Users.Infrastructure.Database.WriteDb.Repositories;
using LearnTop.Modules.Users.Infrastructure.PublicApi;
using LearnTop.Modules.Users.Presentation;
using LearnTop.Modules.Users.PublicApi;
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
        services.AddScoped<IUsersApi, UsersApi>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<UsersDbContext>());
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserViewRepository, UserViewRepository>();
        services.AddDbContext<UsersViewDbContext>(builder =>
        {
            builder.UseSqlServer(configuration.GetConnectionString("ReadDb"));
        });
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
