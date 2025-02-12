using LearnTop.Modules.Categories.Application.Abstractions.Data;
using LearnTop.Modules.Categories.Domain.Categories.Repositories;
using LearnTop.Modules.Categories.Infrastructure.Categories.Repositories;
using LearnTop.Modules.Categories.Infrastructure.Data.WriteDb;
using LearnTop.Modules.Categories.Presentation;
using LearnTop.Shared.Infrastructure.Interceptors;
using LearnTop.Shared.Presentation.Endpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LearnTop.Modules.Categories.Infrastructure;

public static class CategoriesModule
{
    public static IServiceCollection AddCategoriesModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEndpoints(AssemblyReference.Assembly);
        services.AddWriteDb(configuration);
        return services;
    }
    private static void AddWriteDb(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUnitOfWork>(sp=>sp.GetRequiredService<CategoriesDbContext>());
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddDbContext<CategoriesDbContext>((provider, builder) =>
        {
            string? connectionString = configuration.GetConnectionString("WriteDb");
            builder.UseSqlServer(connectionString)
                .AddInterceptors(provider.GetRequiredService<PublishDomainEventsInterceptor>());
        });
    }
}
