using LearnTop.Modules.Academy.Domain.Tickets.Models;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Academy.Domain.Tickets.Events;

public class TicketCreatedEvent(Ticket ticket) : DomainEvent
{
    public Ticket Ticket { get; } = ticket;
}
