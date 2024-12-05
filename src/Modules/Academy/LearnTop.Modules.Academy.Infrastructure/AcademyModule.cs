using LearnTop.Modules.Academy.Domain.Tickets.Repositories;
using LearnTop.Modules.Academy.Infrastructure.Database.ReadDb;
using LearnTop.Modules.Academy.Infrastructure.Database.ReadDb.Repositories;
using LearnTop.Modules.Academy.Infrastructure.Database.WriteDb;
using LearnTop.Modules.Academy.Infrastructure.Database.WriteDb.Repositories;
using LearnTop.Modules.Academy.Presentation;
using LearnTop.Shared.Application.Data;
using LearnTop.Shared.Infrastructure.Interceptors;
using LearnTop.Shared.Presentation.Endpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LearnTop.Modules.Academy.Infrastructure;

public static class AcademyModule
{
    public static IServiceCollection AddAcademyModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddInfrastructure(configuration);
        services.AddEndpoints(AssemblyReference.AcademyAssembly);

        return services;
    }

    private static void AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<ITicketRepository, TicketRepository>();
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<AcademyDbContext>());
        services.AddDbContext<AcademyDbContext>((sp, option) =>
        {
            string connectionString = configuration.GetConnectionString("WriteDb");

            option.UseSqlServer(connectionString)
                .AddInterceptors(sp.GetRequiredService<PublishDomainEventsInterceptor>());
        });

        services.AddScoped<ITicketViewRepository, TicketViewRepository>();
        services.AddDbContext<AcademyViewDbContext>(builder =>
        {
            string connectionString = configuration.GetConnectionString("ReadDb");
            builder.UseSqlServer(connectionString);
        });
    }
}
