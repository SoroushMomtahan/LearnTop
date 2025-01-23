using LearnTop.Shared.Infrastructure.Interceptors;
using LearnTop.Shared.Presentation.Endpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tagging.Data.ReadDb;
using Tagging.Data.WriteDb;

namespace Tagging;

public static class TaggingModule
{
    public static IServiceCollection AddTaggingModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEndpoints(AssemblyReference.TaggingAssembly);
        services.AddDbContext<TaggingDbContext>((sp, option) =>
        {
            string connectionString = configuration.GetConnectionString("WriteDb");
            
            option
                .UseSqlServer(connectionString)
                .AddInterceptors(sp.GetRequiredService<PublishDomainEventsInterceptor>());
        });
        services.AddDbContext<TaggingViewDbContext>((option) =>
        {
            string connectionString = configuration.GetConnectionString("ReadDb");
            option.UseSqlServer(connectionString);
        });
        return services;
    }
}
