using LearnTop.Modules.Identity.Domain.Users.Events;
using LearnTop.Modules.Identity.IntegrationEvent;
using LearnTop.Shared.Application.EventBus;
using LearnTop.Shared.Application.Messaging;

namespace LearnTop.Modules.Identity.Application.Users.EventHandlers;

internal sealed class UserCreatedEventHandler(IEventBus eventBus) : IDomainEventHandler<UserCreatedEvent>
{

    public async Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
    {
        await eventBus.PublishAsync(new UserCreatedIntegrationEvent(
            notification.Id, 
            notification.OccuredOn,
            notification.User.Id,
            notification.User.DisplayName ?? ""),
            cancellationToken);
    }
}
