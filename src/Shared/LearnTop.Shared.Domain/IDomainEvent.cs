using MediatR;

namespace LearnTop.Shared.Domain;

/// <inheritdoc />
public interface IDomainEvent : INotification
{
    /// <summary>
    /// شناسه هر رخداد
    /// </summary>
    Guid Id { get; }
    /// <summary>
    /// تاریخ وقوع هر رخداد
    /// </summary>
    DateTime OccuredOn { get; }
}
