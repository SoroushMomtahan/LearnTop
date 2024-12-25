using LearnTop.Modules.Academy.Domain.Tickets.Events;
using LearnTop.Modules.Academy.Domain.Tickets.Models;
using LearnTop.Modules.Academy.Domain.Tickets.Repositories.Views;
using LearnTop.Modules.Academy.Domain.Tickets.ViewModels;
using LearnTop.Shared.Application.Messaging;

namespace LearnTop.Modules.Academy.Application.Tickets.EventHandlers;

public class TicketCreatedEventHandler(
    ITicketViewRepository ticketViewRepository)
    : IDomainEventHandler<TicketCreatedEvent>
{
    public async Task Handle(TicketCreatedEvent notification, CancellationToken cancellationToken)
    {
        Ticket ticket = notification.Ticket;
        var ticketView = new TicketView
        {
            Id = ticket.Id,
            UserId = ticket.UserId,
            Title = ticket.Title,
            Content = ticket.Content,
            Priority = ticket.Priority.ToString(),
            Status = ticket.Status.ToString(),
            Section = ticket.Section.ToString()
        };
        await ticketViewRepository.AddAsync(ticketView);
        await ticketViewRepository.SaveChangesAsync(cancellationToken);
    }
}
