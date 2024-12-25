using LearnTop.Modules.Academy.Domain.Tickets.Events;
using LearnTop.Modules.Academy.Domain.Tickets.Repositories.Views;
using LearnTop.Modules.Academy.Domain.Tickets.ViewModels;
using LearnTop.Shared.Application.Messaging;

namespace LearnTop.Modules.Academy.Application.Tickets.EventHandlers;

public class TicketEditedEventHandler(
    ITicketViewRepository ticketViewRepository
    )
    : IDomainEventHandler<TicketEditedEvent>
{

    public async Task Handle(TicketEditedEvent notification, CancellationToken cancellationToken)
    {
        var ticketView = new TicketView()
        {
            Id = notification.Ticket.Id,
            Content = notification.Ticket.Content,
            Priority = notification.Ticket.Priority.ToString(),
            Section = notification.Ticket.Section.ToString(),
            Title = notification.Ticket.Title,
            Status = notification.Ticket.Status.ToString()
        };
        await ticketViewRepository.UpdateAsync(ticketView);
        await ticketViewRepository.SaveChangesAsync(cancellationToken);
    }
}
