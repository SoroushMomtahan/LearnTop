using LearnTop.Modules.Ordering.Application.Carts;
using LearnTop.Modules.Ordering.Presentation;
using LearnTop.Shared.Presentation.Endpoints;
using Microsoft.Extensions.DependencyInjection;

namespace LearnTop.Modules.Ordering.Infrastructure;

public static class OrderingModule
{
    public static IServiceCollection AddOrderingModule(this IServiceCollection services)
    {
        services.AddEndpoints(AssemblyReference.Assembly);
        services.AddSingleton<CartService>();
        return services;
    }
}
