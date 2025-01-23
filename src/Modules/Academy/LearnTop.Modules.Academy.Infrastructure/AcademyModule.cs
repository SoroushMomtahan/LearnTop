using LearnTop.Modules.Academy.Application.Abstractions.Data;
using LearnTop.Modules.Academy.Domain.Academy.Repositories;
using LearnTop.Modules.Academy.Domain.Academy.Repositories.Views;
using LearnTop.Modules.Academy.Domain.CourseProposals.Repositories;
using LearnTop.Modules.Academy.Infrastructure.Database.ReadDb;
using LearnTop.Modules.Academy.Infrastructure.Database.ReadDb.Repositories.Tickets;
using LearnTop.Modules.Academy.Infrastructure.Database.WriteDb;
using LearnTop.Modules.Academy.Infrastructure.Database.WriteDb.Repositories.Academy;
using LearnTop.Modules.Academy.Infrastructure.Database.WriteDb.Repositories.CourseProposals;
using LearnTop.Modules.Academy.Presentation;
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
        services.AddRepositories();
        services.AddEndpoints(AssemblyReference.AcademyAssembly);

        return services;
    }

    private static void AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<AcademyDbContext>());

        services.AddDbContext<AcademyDbContext>((sp, option) =>
        {
            string connectionString = configuration.GetConnectionString("WriteDb");

            option.UseSqlServer(connectionString)
                .AddInterceptors(sp.GetRequiredService<PublishDomainEventsInterceptor>());
        });

        services.AddDbContext<AcademyViewDbContext>(builder =>
        {
            string connectionString = configuration.GetConnectionString("ReadDb");
            builder.UseSqlServer(connectionString);
        });
    }
    private static void AddRepositories(this IServiceCollection services)
    {

        services.AddScoped<ICourseProposalRepository, CourseProposalRepository>();

        services.AddScoped<ISkillRepository, SkillRepository>();

        services.AddScoped<IBannerRepository, BannerRepository>();

        services.AddScoped<IBannerViewRepository, BannerViewRepository>();
    }
}
