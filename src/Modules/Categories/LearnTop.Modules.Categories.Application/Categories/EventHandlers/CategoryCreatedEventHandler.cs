using LearnTop.Modules.Categories.Domain.Categories.Events;
using LearnTop.Shared.Application.Messaging;

namespace LearnTop.Modules.Categories.Application.Categories.EventHandlers;

internal sealed class CategoryCreatedEventHandler : IDomainEventHandler<CategoryCreatedEvent>
{

    public Task Handle(CategoryCreatedEvent notification, CancellationToken cancellationToken)
    {
        return Task.FromResult(true);
    }
}
