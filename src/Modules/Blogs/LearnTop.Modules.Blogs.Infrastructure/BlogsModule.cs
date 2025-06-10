using LearnTop.Modules.Blogs.Application;
using LearnTop.Modules.Blogs.Application.Abstractions.Data;
using LearnTop.Modules.Blogs.Application.Snapshots.UserSnapshots.Services;
using LearnTop.Modules.Blogs.Application.Views.ArticleViews.Repositories;
using LearnTop.Modules.Blogs.Domain.Articles.Repositories;
using LearnTop.Modules.Blogs.Infrastructure.Articles;
using LearnTop.Modules.Blogs.Infrastructure.ArticleViews.Repositories;
using LearnTop.Modules.Blogs.Infrastructure.Data.ReadDb;
using LearnTop.Modules.Blogs.Infrastructure.Data.SnapshotsDb;
using LearnTop.Modules.Blogs.Infrastructure.Data.WriteDb;
using LearnTop.Modules.Blogs.Infrastructure.UserSnapshots.Repositories;
using LearnTop.Modules.Blogs.Presentation.Snapshots.Users;
using LearnTop.Shared.Infrastructure.Interceptors;
using LearnTop.Shared.Presentation.Endpoints;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AssemblyReference = LearnTop.Modules.Blogs.Presentation.AssemblyReference;

namespace LearnTop.Modules.Blogs.Infrastructure;

public static class BlogsModule
{
    public static IServiceCollection AddBlogsModule(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddInfrastructure(configuration);
        services.AddEndpoints(AssemblyReference.BlogsEndpointsAssembly);
        return services;
    }
    public static void ConfigureConsumer(IRegistrationConfigurator registrationConfigurator)
    {
        registrationConfigurator.AddConsumer<UserCreatedIntegrationEventConsumer>();
    }
    private static void AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddWriteDb(configuration);
        services.AddReadDb(configuration);
        services.AddSnapshotDb(configuration);
    }
    private static void AddWriteDb(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IArticleRepository, ArticleRepository>();
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<BlogsDbContext>());
        services.AddDbContext<BlogsDbContext>((sp, option) =>
        {
            string connectionString = configuration.GetConnectionString("WriteDb");
            
            option
                .UseSqlServer(connectionString)
                .AddInterceptors(sp.GetRequiredService<PublishDomainEventsInterceptor>());
        });
    }
    private static void AddReadDb(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IArticleViewRepository, ArticleViewRepository>();
        services.AddDbContext<BlogsViewsDbContext>(option =>
        {
            string connectionString = configuration.GetConnectionString("ReadDb");
            option.UseSqlServer(connectionString);
        });
    }
    private static void AddSnapshotDb(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUserSnapshotRepository, UserSnapshotsRepository>();
        
        services.AddDbContext<BlogsSnapshotsDbContext>(builder =>
        {
            string connectionString = configuration.GetConnectionString("SnapshotsDb");
            builder.UseSqlServer(connectionString);
        });
    }
}
