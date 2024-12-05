namespace LearnTop.Shared.Domain;

/// <summary>
/// قالبی برای کلاس های رخداد
/// </summary>
/// <param name="id"></param>
/// <param name="occuredOn"></param>
public abstract class DomainEvent(Guid id, DateTime occuredOn) : IDomainEvent
{
    /// <inheritdoc />
    public Guid Id { get; } = id;
    /// <inheritdoc />
    public DateTime OccuredOn { get; } = occuredOn;

    /// <inheritdoc />
    protected DomainEvent() : this(Guid.NewGuid(), DateTime.Now)
    {
    }
}
