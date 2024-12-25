using LearnTop.Modules.Blogs.Domain.Blogs.Models;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Domain.Blogs.Events;

public class CommentAddedEvent(Comment comment) : DomainEvent
{
    public Comment Comment { get; } = comment;
}
