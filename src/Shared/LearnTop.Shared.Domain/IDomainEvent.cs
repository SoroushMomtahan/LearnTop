using MediatR;

namespace LearnTop.Shared.Domain;

/// <inheritdoc />
public interface IDomainEvent : INotification
{
    /// <summary>
    /// شناسه هر رخداد
    /// </summary>
    public Guid Id { get; }
    /// <summary>
    /// تاریخ وقوع هر رخداد
    /// </summary>
    public DateTime OccuredOn { get; }
}
