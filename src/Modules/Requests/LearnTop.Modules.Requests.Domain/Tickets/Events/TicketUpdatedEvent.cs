using LearnTop.Modules.Requests.Domain.Tickets.Models;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Requests.Domain.Tickets.Events;

public class TicketUpdatedEvent(Ticket ticket) : DomainEvent
{
    public Ticket Ticket { get; set; } = ticket;
}
