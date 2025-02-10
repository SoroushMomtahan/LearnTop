using LearnTop.Modules.Academy.Infrastructure.Banners.Repositories;
using LearnTop.Modules.Academy.Infrastructure.Data.WriteDb;
using LearnTop.Modules.Information.Application.Abstractions.Data;
using LearnTop.Modules.Academy.Presentation;
using LearnTop.Modules.Information.Domain.Banners.Repositories;
using LearnTop.Shared.Infrastructure.Interceptors;
using LearnTop.Shared.Presentation.Endpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LearnTop.Modules.Academy.Infrastructure;

public static class InformationModule
{
    public static IServiceCollection AddInformationModule(
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
        services.AddWriteDb(configuration);
    }
    private static void AddWriteDb(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<InformationDbContext>());
        services.AddScoped<IBannerRepository, BannerRepository>();
        
        services.AddDbContext<InformationDbContext>((sp, option) =>
        {
            string connectionString = configuration.GetConnectionString("WriteDb");

            option.UseSqlServer(connectionString)
                .AddInterceptors(sp.GetRequiredService<PublishDomainEventsInterceptor>());
        });
    }
}
