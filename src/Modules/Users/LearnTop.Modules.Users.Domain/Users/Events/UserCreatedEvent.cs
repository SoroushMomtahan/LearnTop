using LearnTop.Modules.Users.Domain.Users.Models;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Users.Domain.Users.Events;

public class UserCreatedEvent(User user) : DomainEvent
{
    public User User { get; } = user;
}
