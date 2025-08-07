using MediatR;

namespace LearnTop.Shared.Application.Messaging;

public interface IApplicationEventHandler<in TApplicationEvent>
    : INotificationHandler<TApplicationEvent>
    where TApplicationEvent : IApplicationEvent;
