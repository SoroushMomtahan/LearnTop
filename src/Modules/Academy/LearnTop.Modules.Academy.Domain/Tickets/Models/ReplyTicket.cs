using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Academy.Domain.Tickets.Models;

public sealed class ReplyTicket : Entity
{
    public Guid UserId { get; private set; }
    public Guid TicketId { get; private set; }
    public string Content { get; private set; }

    public byte[] Version { get; set; }

    private ReplyTicket(Guid userId, Guid ticketId, string content)
    {
        UserId = userId;
        Content = content;
        TicketId = ticketId;
    }

    public static Result<ReplyTicket> CreateReplyTicket(Guid userId, Guid ticketId, string content)
    {
        return new ReplyTicket(userId, ticketId, content);
    }

    public void Edit(string content)
    {
        Content = content;
    }
}
