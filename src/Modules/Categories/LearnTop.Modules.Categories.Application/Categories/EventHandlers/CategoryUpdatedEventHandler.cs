using LearnTop.Modules.Categories.Domain.Categories.Events;
using LearnTop.Shared.Application.Messaging;

namespace LearnTop.Modules.Categories.Application.Categories.EventHandlers;

internal sealed class CategoryUpdatedEventHandler : IDomainEventHandler<CategoryUpdatedEvent>
{

    public Task Handle(CategoryUpdatedEvent notification, CancellationToken cancellationToken)
    {
        return Task.FromResult(true);
    }
}
