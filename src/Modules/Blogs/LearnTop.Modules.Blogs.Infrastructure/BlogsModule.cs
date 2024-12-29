using LearnTop.Modules.Blogs.Application;
using LearnTop.Modules.Blogs.Application.Abstractions.Data;
using LearnTop.Modules.Blogs.Domain.Articles.Repositories;
using LearnTop.Modules.Blogs.Domain.Articles.Views;
using LearnTop.Modules.Blogs.Infrastructure.Articles;
using LearnTop.Modules.Blogs.Infrastructure.ArticleViews;
using LearnTop.Modules.Blogs.Infrastructure.ReadDb;
using LearnTop.Modules.Blogs.Infrastructure.WriteDb;
using LearnTop.Shared.Infrastructure.Interceptors;
using LearnTop.Shared.Presentation.Endpoints;
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
    private static void AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddWriteDb(configuration);
        services.AddReadDb(configuration);
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
        services.AddScoped<IArticleTagViewRepository, ArticleTagViewRepository>();
        services.AddDbContext<BlogViewsDbContext>(option =>
        {
            string connectionString = configuration.GetConnectionString("ReadDb");
            option.UseSqlServer(connectionString);
        });
    }
}
