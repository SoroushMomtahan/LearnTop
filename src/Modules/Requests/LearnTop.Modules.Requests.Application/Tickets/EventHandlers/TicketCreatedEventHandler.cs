using LearnTop.Modules.Requests.Domain.Tickets.Events;
using LearnTop.Modules.Requests.Domain.Tickets.Models;
using LearnTop.Modules.Requests.Domain.Tickets.Repositories.Views;
using LearnTop.Modules.Requests.Domain.Tickets.ViewModels;
using LearnTop.Shared.Application.Messaging;

namespace LearnTop.Modules.Requests.Application.Tickets.EventHandlers;

public class TicketCreatedEventHandler(
    ITicketViewRepository ticketViewRepository)
    : IDomainEventHandler<TicketCreatedEvent>
{
    public async Task Handle(TicketCreatedEvent notification, CancellationToken cancellationToken)
    {
        Ticket ticket = notification.Ticket;
        TicketView ticketView = new()
        {
            Id = ticket.Id,
            UserId = ticket.UserId,
            Title = ticket.Title,
            Content = ticket.Content,
            Priority = ticket.Priority.ToString(),
            Status = ticket.Status.ToString(),
            Section = ticket.Section.ToString(),
            CreatedAt = ticket.CreatedAt,
            UpdatedAt = ticket.UpdatedAt,
            DeletedAt = ticket.DeletedAt,
            ReplyTicketViews = []
        };
        await ticketViewRepository.AddAsync(ticketView);
        await ticketViewRepository.SaveChangesAsync(cancellationToken);
    }
}
