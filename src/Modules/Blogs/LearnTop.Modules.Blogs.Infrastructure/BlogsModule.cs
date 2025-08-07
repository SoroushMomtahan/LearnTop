using LearnTop.Modules.Blogs.Application.Abstractions.Data;
using LearnTop.Modules.Blogs.Application.Authors.Services;
using LearnTop.Modules.Blogs.Domain.Aggregates.Articles.Repositories;
using LearnTop.Modules.Blogs.Domain.Aggregates.Authors.Repositories;
using LearnTop.Modules.Blogs.Infrastructure.Articles.Repositories;
using LearnTop.Modules.Blogs.Infrastructure.Articles.Services;
using LearnTop.Modules.Blogs.Infrastructure.Authors.Repositories;
using LearnTop.Modules.Blogs.Infrastructure.Authors.Services;
using LearnTop.Modules.Blogs.Infrastructure.Data.ReadDb;
using LearnTop.Modules.Blogs.Infrastructure.Data.WriteDb;
using LearnTop.Modules.Blogs.Presentation.Authors.EventConsumers.CreateAuthorByUser;
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
    }
    private static void AddWriteDb(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IArticleRepository, ArticleRepository>();
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        
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
        services.AddScoped<ArticleQueryService, ArticleQueryService>();
        services.AddScoped<IAuthorQueryService, AuthorQueryService>();
        services.AddDbContext<BlogsViewsDbContext>(option =>
        {
            string connectionString = configuration.GetConnectionString("ReadDb");
            option.UseSqlServer(connectionString);
        });
    }
}
