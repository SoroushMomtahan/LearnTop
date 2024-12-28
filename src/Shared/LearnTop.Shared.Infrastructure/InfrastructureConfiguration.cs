using LearnTop.Shared.Application.Caching;
using LearnTop.Shared.Application.EventBus;
using LearnTop.Shared.Infrastructure.Authentication;
using LearnTop.Shared.Infrastructure.Caching;
using LearnTop.Shared.Infrastructure.Interceptors;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using StackExchange.Redis;

namespace LearnTop.Shared.Infrastructure;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructureConfiguration(
        this IServiceCollection services,
        string redisConnectionString)
    {
        services.AddAuthenticationInternal();
        services.TryAddSingleton<ICacheService, CacheService>();

        services.TryAddSingleton<PublishDomainEventsInterceptor>();

        IConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect(redisConnectionString);
        services.TryAddSingleton(connectionMultiplexer);

        services.AddStackExchangeRedisCache(
            options => options.ConnectionMultiplexerFactory = () => Task.FromResult(connectionMultiplexer));
        return services;
    }
}
