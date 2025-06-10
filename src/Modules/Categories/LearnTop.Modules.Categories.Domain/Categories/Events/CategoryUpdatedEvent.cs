using LearnTop.Modules.Categories.Domain.Categories.Models;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Categories.Domain.Categories.Events;

public class CategoryUpdatedEvent(Category category) : DomainEvent
{
    public Category Category { get; } = category;
}
