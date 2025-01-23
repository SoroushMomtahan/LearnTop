using LearnTop.Modules.Requests.Domain.Tickets.Events;
using LearnTop.Modules.Requests.Domain.Tickets.Models;
using LearnTop.Modules.Requests.Domain.Tickets.Repositories.Views;
using LearnTop.Modules.Requests.Domain.Tickets.ViewModels;
using LearnTop.Shared.Application.Exceptions;
using LearnTop.Shared.Application.Messaging;

namespace LearnTop.Modules.Requests.Application.Tickets.EventHandlers;

public class TicketUpdatedEventHandler(
    ITicketViewRepository ticketViewRepository
    )
    : IDomainEventHandler<TicketUpdatedEvent>
{

    public async Task Handle(TicketUpdatedEvent notification, CancellationToken cancellationToken)
    {
        TicketView? ticketView = await ticketViewRepository.GetAsync(notification.Ticket.Id);
        if (ticketView == null)
        {
            throw new LearnTopException(nameof(TicketUpdatedEventHandler));
        }
        var replyTicketViews = notification.Ticket.ReplyTickets
            .Select(replyTicket => new ReplyTicketView()
            {
                Id = replyTicket.Id,
                UserId = replyTicket.UserId,
                TicketViewId = replyTicket.TicketId,
                Content = replyTicket.Content,
                CreatedAt = replyTicket.CreatedAt,
                UpdatedAt = replyTicket.UpdatedAt,
                DeletedAt = replyTicket.DeletedAt,
            }).ToList();

        Console.WriteLine(replyTicketViews);
        
        ticketView.Id = notification.Ticket.Id;
        ticketView.Content = notification.Ticket.Content;
        ticketView.Priority = notification.Ticket.Priority.ToString();
        ticketView.Section = notification.Ticket.Section.ToString();
        ticketView.Title = notification.Ticket.Title;
        ticketView.Status = notification.Ticket.Status.ToString();
        ticketView.CreatedAt = notification.Ticket.CreatedAt;
        ticketView.UpdatedAt = notification.Ticket.UpdatedAt;
        ticketView.DeletedAt = notification.Ticket.DeletedAt;
        ticketView.ReplyTicketViews = [];
        
        await ticketViewRepository.SaveChangesAsync(cancellationToken);
    }
}
