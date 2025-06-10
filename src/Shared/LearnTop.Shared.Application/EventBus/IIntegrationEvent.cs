namespace LearnTop.Shared.Application.EventBus;

public interface IIntegrationEvent
{
    Guid Id { get; }
    DateTime OccuredOn { get; }
}

