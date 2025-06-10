namespace LearnTop.Modules.Identity.IntegrationEvent;

public class UserCreatedIntegrationEvent(
    Guid id, 
    DateTime occuredOn,
    Guid userId,
    string displayName) : 
    Shared.Application.EventBus.IntegrationEvent(id, occuredOn)
{
    public Guid UserId { get; init; } = userId;
    public string? DisplayName { get; init; } = displayName;
}
