using LearnTop.Modules.Requests.Application.Abstractions;
using LearnTop.Modules.Requests.Presentation;
using LearnTop.Modules.Requests.Domain.Tickets.Repositories;
using LearnTop.Modules.Requests.Domain.Tickets.Repositories.Views;
using LearnTop.Modules.Requests.Infrastructure.ReadDb;
using LearnTop.Modules.Requests.Infrastructure.Tickets.Repositories;
using LearnTop.Modules.Requests.Infrastructure.WriteDb;
using LearnTop.Shared.Infrastructure.Interceptors;
using LearnTop.Shared.Presentation.Endpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LearnTop.Modules.Requests.Infrastructure;

public static class RequestsModule
{
    public static IServiceCollection AddRequestsModule(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddInfrastructure(configuration);
        services.AddEndpoints(AssemblyReference.RequestsEndpointAssembly);
        return services;
    }
    private static void AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddWriteDb(configuration);
        services.AddReadDb(configuration);
    }
    
    private static void AddWriteDb(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddScoped<ITicketRepository, TicketRepository>();
        services.AddScoped<IUnitOfWork>(serviceProvider => 
            serviceProvider.GetRequiredService<RequestsDbContext>());
        services.AddDbContext<RequestsDbContext>((sp, option) =>
        {
            string connectionString = configuration.GetConnectionString("WriteDb");
            option.UseSqlServer(connectionString)
                .AddInterceptors(sp.GetRequiredService<PublishDomainEventsInterceptor>());
        });
    }
    private static void AddReadDb(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddScoped<ITicketViewRepository, TicketViewRepository>();
        services.AddDbContext<RequestsViewDbContext>(option =>
        {
            string connectionString = configuration.GetConnectionString("ReadDb");
            option.UseSqlServer(connectionString);
        });
    }
}
