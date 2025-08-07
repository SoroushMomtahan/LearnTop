using LearnTop.Modules.Blogs.Domain.Aggregates.Authors.Models;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Domain.Aggregates.Authors.Events;

public sealed class AuthorUpdatedEvent(Author author) : DomainEvent
{
    public Author Author { get; } = author;
}
