using LearnTop.Modules.Users.Domain.Users.Events;
using LearnTop.Modules.Users.Domain.Users.Repositories;
using LearnTop.Modules.Users.Domain.Users.ViewModels;
using LearnTop.Modules.Users.IntegrationEvents;
using LearnTop.Shared.Application.EventBus;
using LearnTop.Shared.Application.Messaging;

namespace LearnTop.Modules.Users.Application.Users.EventHandlers;

public class UserCreatedEventHandler
    : IDomainEventHandler<UserCreatedEvent>
{

    public Task Handle(
        UserCreatedEvent notification,
        CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
