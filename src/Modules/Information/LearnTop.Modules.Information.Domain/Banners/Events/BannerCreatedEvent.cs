using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Information.Domain.Banners.Events;

public class BannerCreatedEvent(Guid bannerId) : DomainEvent
{
    public Guid BannerId { get; init; } = bannerId;
}
