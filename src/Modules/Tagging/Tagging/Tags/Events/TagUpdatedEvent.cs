using LearnTop.Shared.Domain;

namespace Tagging.Tags.Events;

internal sealed class TagUpdatedEvent(Models.Tag tag) : DomainEvent
{
    public Models.Tag Tag { get; } = tag;
}
