using LearnTop.Modules.Requests.Domain.Tickets.Models;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Requests.Domain.Tickets.Events;

public class TicketCreatedEvent(Ticket ticket) : DomainEvent
{
    public Ticket Ticket { get; } = ticket;
}
