using LearnTop.Modules.Identity.Domain.Users.Models;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Identity.Domain.Users.Events;

public class UserUpdatedEvent(User user) : DomainEvent
{
    public User User { get; } = user;
}
