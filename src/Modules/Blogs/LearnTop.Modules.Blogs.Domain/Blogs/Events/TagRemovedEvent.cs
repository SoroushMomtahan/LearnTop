using LearnTop.Modules.Blogs.Domain.Blogs.Models;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Domain.Blogs.Events;

public class TagRemovedEvent(Tag tag) : DomainEvent
{
    public Tag Tag { get; } = tag;
}
