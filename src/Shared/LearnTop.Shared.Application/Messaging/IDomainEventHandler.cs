using LearnTop.Shared.Domain;
using MediatR;

namespace LearnTop.Shared.Application.Messaging;

public interface IDomainEventHandler<in TDomainEvent> : INotificationHandler<TDomainEvent>
    where TDomainEvent : IDomainEvent;
