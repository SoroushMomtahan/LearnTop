using LearnTop.Modules.Blogs.Domain.Blogs.Models;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Domain.Blogs.Events;

public sealed class BlogUpdatedEvent(Blog blog) : DomainEvent
{
    public Blog Blog { get; } = blog;
}
