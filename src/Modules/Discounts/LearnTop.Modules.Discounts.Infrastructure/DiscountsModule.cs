using LearnTop.Modules.Discounts.Application.Abstractions.Data;
using LearnTop.Modules.Discounts.Domain.Discounts.Repositories;
using LearnTop.Modules.Discounts.Infrastructure.Data.WriteDb;
using LearnTop.Modules.Discounts.Infrastructure.Discounts.Repositories;
using LearnTop.Modules.Discounts.Presentation;
using LearnTop.Shared.Infrastructure.Interceptors;
using LearnTop.Shared.Presentation.Endpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LearnTop.Modules.Discounts.Infrastructure;

public static class DiscountsModule
{
    public static IServiceCollection AddDiscountsModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEndpoints(AssemblyReference.Assembly);
        services.AddWriteDb(configuration);
        return services;
    }
    private static void AddWriteDb(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUnitOfWork>(sp=>sp.GetRequiredService<DiscountsDbContext>());
        services.AddScoped<IDiscountRepository, DiscountRepository>();
        string? connectionString = configuration.GetConnectionString("WriteDb");
        services.AddDbContext<DiscountsDbContext>((provider, builder) =>
        {
            builder.UseSqlServer(connectionString)
                .AddInterceptors(provider.GetRequiredService<PublishDomainEventsInterceptor>());
        });
    }
}
