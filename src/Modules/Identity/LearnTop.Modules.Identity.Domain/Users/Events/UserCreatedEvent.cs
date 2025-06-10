using LearnTop.Modules.Identity.Domain.Users.Models;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Identity.Domain.Users.Events;

public class UserCreatedEvent(User user) : DomainEvent
{
    public User User { get; } = user;
}
