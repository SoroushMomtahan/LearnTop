namespace LearnTop.Shared.Domain;


/// <summary>
/// قالبی برای کلاس های تجمیع
/// </summary>
public class Aggregate : Entity
{
    private readonly List<IDomainEvent> _domainEvents = [];
    /// <summary>
    /// لیستی شامل رخداد های یک دامنه
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => [.. _domainEvents];

    /// <summary>
    /// متدی برای اضافه کردن رخداد به رخداد های دامنه
    /// </summary>
    /// <param name="domainEvent"></param>
    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    /// <summary>
    /// متدی برای پاکسازی کلیه رخداد های دامنه
    /// </summary>
    public void Clear()
    {
        _domainEvents.Clear();
    }
}
