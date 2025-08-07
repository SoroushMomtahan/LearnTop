using LearnTop.Modules.Blogs.Domain.Lookups.Categories.Models;
using LearnTop.Shared.Application.Messaging;

namespace LearnTop.Modules.Blogs.Application.Categories.Events;

public sealed class CategoryCreatedEvent(Category category) : ApplicationEvent
{
    public Category Category { get; } = category;
}
