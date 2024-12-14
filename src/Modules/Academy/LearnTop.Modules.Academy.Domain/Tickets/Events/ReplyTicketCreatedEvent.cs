using LearnTop.Modules.Academy.Domain.Tickets.Models;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Academy.Domain.Tickets.Events;

public sealed class ReplyTicketCreatedEvent(ReplyTicket replyTicket) : DomainEvent
{
    public ReplyTicket ReplyTicket { get; set; } = replyTicket;
}
