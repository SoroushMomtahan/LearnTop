using LearnTop.Shared.Application.Caching;
using LearnTop.Shared.Application.EventBus;
using LearnTop.Shared.Infrastructure.Authentication;
using LearnTop.Shared.Infrastructure.Authorization;
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
        Action<IRegistrationConfigurator>[] moduleConfigureConsumers, 
        string redisConnectionString)
    {
        services.AddAuthenticationInternal();
        services.AddAuthorizationInternal();

        services.AddRedisCache(redisConnectionString);
        services.AddMessaging(moduleConfigureConsumers);
        
        return services;
    }
    private static void AddRedisCache(this IServiceCollection services, string redisConnectionString)
    {
        services.TryAddSingleton<ICacheService, CacheService>();
        
        IConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect(redisConnectionString);
        services.TryAddSingleton(connectionMultiplexer);

        services.AddStackExchangeRedisCache(
            options => options.ConnectionMultiplexerFactory = () => Task.FromResult(connectionMultiplexer));
    }
    private static void AddMessaging(
        this IServiceCollection services, 
        Action<IRegistrationConfigurator>[] moduleConfigureConsumers)
    {
        services.TryAddSingleton<PublishDomainEventsInterceptor>();
        
        services.AddSingleton<IEventBus, EventBus.EventBus>();
        services.AddMassTransit(config =>
        {
            foreach (Action<IRegistrationConfigurator> moduleConfigureConsumer in moduleConfigureConsumers)
            {
                moduleConfigureConsumer(config);
            }
            config.UsingInMemory((context, cfg) =>
            {
                cfg.ConfigureEndpoints(context);
            });
        });
    }
}
