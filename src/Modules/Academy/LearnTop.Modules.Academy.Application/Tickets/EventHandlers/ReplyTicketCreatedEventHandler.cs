using LearnTop.Modules.Academy.Domain.Tickets.Events;
using LearnTop.Modules.Academy.Domain.Tickets.Repositories;
using LearnTop.Modules.Academy.Domain.Tickets.ViewModels;
using LearnTop.Shared.Application.Messaging;

namespace LearnTop.Modules.Academy.Application.Tickets.EventHandlers;

public sealed class ReplyTicketCreatedEventHandler(
    ITicketViewRepository ticketViewRepository
    )
    : IDomainEventHandler<ReplyTicketCreatedEvent>
{

    public async Task Handle(ReplyTicketCreatedEvent notification, CancellationToken cancellationToken)
    {
        var replyTicketView = new ReplyTicketView()
        {
            Id = notification.ReplyTicket.Id,
            Content = notification.ReplyTicket.Content,
            TicketViewId = notification.ReplyTicket.TicketId,
            UserId = notification.ReplyTicket.UserId,
        };
        await ticketViewRepository.AddReplyTicketViewAsync(replyTicketView);
        await ticketViewRepository.SaveChangesAsync(cancellationToken);
    }
}
