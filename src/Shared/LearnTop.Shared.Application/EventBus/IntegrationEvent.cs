namespace LearnTop.Shared.Application.EventBus;

public abstract class IntegrationEvent(Guid id, DateTime occuredOn) : IIntegrationEvent
{

    public Guid Id { get; init; } = id;
    public DateTime OccuredOn { get; init; } = occuredOn;
}
