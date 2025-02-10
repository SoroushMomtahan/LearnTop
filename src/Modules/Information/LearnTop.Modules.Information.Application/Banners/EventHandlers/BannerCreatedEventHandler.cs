using LearnTop.Modules.Information.Domain.Banners.Events;
using LearnTop.Shared.Application.Messaging;

namespace LearnTop.Modules.Information.Application.Banners.EventHandlers;

public class BannerCreatedEventHandler()
    : IDomainEventHandler<BannerCreatedEvent>
{

    public Task Handle(BannerCreatedEvent notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
