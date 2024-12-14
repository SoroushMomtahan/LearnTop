using LearnTop.Modules.Academy.Domain.Tickets.Models;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Academy.Domain.Tickets.Events;

public class TicketEditedEvent(Ticket ticket) : DomainEvent
{
    public Ticket Ticket { get; set; } = ticket;
}
