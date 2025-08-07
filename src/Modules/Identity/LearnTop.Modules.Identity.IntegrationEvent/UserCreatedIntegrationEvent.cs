namespace LearnTop.Modules.Identity.IntegrationEvent;

public class UserCreatedIntegrationEvent(
    Guid id, 
    DateTime occuredOn,
    Guid userId,
    string username,
    string? displayName
        ) : Shared.Application.EventBus.IntegrationEvent(id, occuredOn)
{
    public Guid UserId { get; init; } = userId;
    public string Username { get; init; } = username;
    public string? DisplayName { get; init; } = displayName;
}
