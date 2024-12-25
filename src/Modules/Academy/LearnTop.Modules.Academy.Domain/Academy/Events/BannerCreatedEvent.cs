using LearnTop.Modules.Academy.Domain.Academy.Models;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Academy.Domain.Academy.Events;

public class BannerCreatedEvent(Banner banner) : DomainEvent
{
    public Banner Banner { get; } = banner;
}
