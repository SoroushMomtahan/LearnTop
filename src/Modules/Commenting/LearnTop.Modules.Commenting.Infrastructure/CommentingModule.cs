using LearnTop.Modules.Commenting.Application.Abstractions.Data;
using LearnTop.Modules.Commenting.Domain.Comments.Repositories;
using LearnTop.Modules.Commenting.Infrastructure.Comments.Repositories;
using LearnTop.Modules.Commenting.Infrastructure.Data.WriteDb;
using LearnTop.Modules.Commenting.Presentation;
using LearnTop.Shared.Infrastructure.Interceptors;
using LearnTop.Shared.Presentation.Endpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LearnTop.Modules.Commenting.Infrastructure;

public static class CommentingModule
{
    public static IServiceCollection AddCommentingModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEndpoints(AssemblyReference.Assembly);
        services.AddWriteDb(configuration);
        return services;
    }
    private static void AddWriteDb(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<CommentingDbContext>());
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddDbContext<CommentingDbContext>((provider, builder) =>
        {
            string connectionString = configuration.GetConnectionString("WriteDb");
            builder.UseSqlServer(connectionString)
                .AddInterceptors(provider.GetRequiredService<PublishDomainEventsInterceptor>());
        });
    }
}
