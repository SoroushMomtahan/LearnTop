using LearnTop.Modules.Identity.Domain.Users.Events;
using LearnTop.Shared.Application.Messaging;

namespace LearnTop.Modules.Identity.Application.Users.EventHandlers;

internal sealed class UserUpdatedEventHandler : IDomainEventHandler<UserUpdatedEvent>
{

    public Task Handle(UserUpdatedEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
