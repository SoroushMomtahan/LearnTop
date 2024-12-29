namespace LearnTop.Shared.Domain;

public abstract class DomainEvent(Guid id, DateTime occuredOn) : IDomainEvent
{
    public Guid Id { get; } = id;
    public DateTime OccuredOn { get; } = occuredOn;
    protected DomainEvent() : this(Guid.NewGuid(), DateTime.Now)
    {
    }
}
