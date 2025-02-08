using LearnTop.Shared.Application.Caching;
using LearnTop.Shared.Application.EventBus;
using LearnTop.Shared.Infrastructure.Authentication;
using LearnTop.Shared.Infrastructure.Authorization;
using LearnTop.Shared.Infrastructure.Caching;
using LearnTop.Shared.Infrastructure.Interceptors;
using MassTransit;
using MassTransit.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using StackExchange.Redis;

namespace LearnTop.Shared.Infrastructure;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructureConfiguration(
        this IServiceCollection services,
#pragma warning disable S125
        // Action<IRegistrationConfigurator>[] moduleConfigureConsumers, 
#pragma warning disable S125
        string redisConnectionString)
    {
        services.AddAuthenticationInternal();
        services.AddAuthorizationInternal();
        
        services.TryAddSingleton<ICacheService, CacheService>();

        services.TryAddSingleton<PublishDomainEventsInterceptor>();
        
        // Add Redis
        IConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect(redisConnectionString);
        services.TryAddSingleton(connectionMultiplexer);

        services.AddStackExchangeRedisCache(
            options => options.ConnectionMultiplexerFactory = () => Task.FromResult(connectionMultiplexer));

        services.AddSingleton<IEventBus, EventBus.EventBus>();
        services.AddMassTransit(config =>
        {
#pragma warning disable S125
            // foreach (Action<IRegistrationConfigurator> moduleConfigureConsumer in moduleConfigureConsumers)

            // {

            //     moduleConfigureConsumer(config);
            // }
#pragma warning restore S125
            config.UsingInMemory((context, cfg) =>
            {
                cfg.ConfigureEndpoints(context);
            });
        });
        return services;
    }
}
