namespace LearnTop.Shared.Application.EventBus;

public interface IIntegrationEvent
{
    public Guid Id { get; }
    public DateTime OccuredOn { get; }
}

