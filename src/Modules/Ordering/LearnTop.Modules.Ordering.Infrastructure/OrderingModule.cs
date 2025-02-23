using LearnTop.Modules.Ordering.Application.Abstractions.Data;
using LearnTop.Modules.Ordering.Application.Carts;
using LearnTop.Modules.Ordering.Domain.Coupons.Repositories;
using LearnTop.Modules.Ordering.Domain.Discounts.Repositories;
using LearnTop.Modules.Ordering.Domain.Orders.Repositories;
using LearnTop.Modules.Ordering.Domain.Products.Repositories;
using LearnTop.Modules.Ordering.Infrastructure.Coupons.Repositories;
using LearnTop.Modules.Ordering.Infrastructure.Data.WriteDb;
using LearnTop.Modules.Ordering.Infrastructure.Discounts.Repositories;
using LearnTop.Modules.Ordering.Infrastructure.Orders.Repositories;
using LearnTop.Modules.Ordering.Infrastructure.Products.Repositories;
using LearnTop.Modules.Ordering.Presentation;
using LearnTop.Shared.Infrastructure.Interceptors;
using LearnTop.Shared.Presentation.Endpoints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LearnTop.Modules.Ordering.Infrastructure;

public static class OrderingModule
{
    public static IServiceCollection AddOrderingModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddWriteDb(configuration);
        services.AddEndpoints(AssemblyReference.Assembly);
        services.AddSingleton<CartService>();
        return services;
    }
    private static void AddWriteDb(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICouponRepository, CouponRepository>();
        services.AddScoped<IDiscountRepository, DiscountRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IUnitOfWork>(sp=>sp.GetRequiredService<OrderingDbContext>());
        string? connectionString = configuration.GetConnectionString("WriteDb");
        services.AddDbContext<OrderingDbContext>((provider, builder) =>
        {
            builder.UseSqlServer(connectionString)
                .AddInterceptors(provider.GetRequiredService<PublishDomainEventsInterceptor>());
        });
    }
}
