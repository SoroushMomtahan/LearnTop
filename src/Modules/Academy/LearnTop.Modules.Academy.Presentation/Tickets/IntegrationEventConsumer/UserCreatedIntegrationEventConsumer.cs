using LearnTop.Modules.Users.IntegrationEvents;
using MassTransit;

namespace LearnTop.Modules.Academy.Presentation.Tickets.IntegrationEventConsumer;

public sealed class UserCreatedIntegrationEventConsumer : IConsumer<UserCreatedIntegrationEvent>
{
    public Task Consume(ConsumeContext<UserCreatedIntegrationEvent> context)
    {
        // use ISender to duplication data between modules
        throw new NotImplementedException();
    }
}
