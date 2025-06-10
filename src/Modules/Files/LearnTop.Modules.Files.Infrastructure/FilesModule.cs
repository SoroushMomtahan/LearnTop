using LearnTop.Modules.Files.Application.Abstractions;
using LearnTop.Modules.Files.Domain.Files.Repositories;
using LearnTop.Modules.Files.Infrastructure.Data;
using LearnTop.Modules.Files.Infrastructure.Files.Db.Repositories;
using LearnTop.Modules.Files.Infrastructure.Files.Services;
using LearnTop.Modules.Files.Presentation;
using LearnTop.Shared.Infrastructure.Interceptors;
using LearnTop.Shared.Presentation.Endpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LearnTop.Modules.Files.Infrastructure;

public static class FilesModule
{
    public static IServiceCollection AddFilesModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddFilesInfrastructure(configuration);
        services.AddEndpoints(AssemblyReference.Assembly);
        return services;
    }
    private static void AddFilesInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddFileServices();
        services.AddDb(configuration);
    }
    private static void AddDb(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<FilesDbContext>((provider, builder) =>
        {
            string connectionString = configuration.GetConnectionString("WriteDb");
            builder.UseSqlServer(connectionString)
                .AddInterceptors(provider.GetRequiredService<PublishDomainEventsInterceptor>());
        });
        services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<FilesDbContext>());
        services.AddScoped<IFileRepository, FileRepository>();
        services.AddScoped<IImageFileRepository, ImageFileRepository>();
    }
}
