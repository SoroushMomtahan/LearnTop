using LearnTop.Shared.Application.EventBus;

namespace LearnTop.Modules.Users.IntegrationEvents;

public class UserCreatedIntegrationEvent(Guid id, DateTime occuredOn) : IntegrationEvent(id, occuredOn)
{
    public Guid UserId { get; init; }
    public string Firstname { get; init; }
    public string Lastname { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }
}
