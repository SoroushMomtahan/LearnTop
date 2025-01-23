using LearnTop.Modules.Requests.Domain.Tickets.Errors;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Requests.Domain.Tickets.Models;

public class ReplyTicket : Entity
{
    public Guid UserId { get; private set; }
    public Guid TicketId { get; private set; }
    public string Content { get; private set; }
    
    private ReplyTicket() { }

    public static Result<ReplyTicket> Create(Guid userId, string content)
    {
        if (content.Length < 3)
        {
            return Result.Failure<ReplyTicket>(TicketErrors.ContentLessThan3Character);
        }
        ReplyTicket replyTicket = new()
        {
            UserId = userId,
            Content = content,
        };
        return replyTicket;
    }

    public Result Edit(string content)
    {
        if (content.Length < 3)
        {
            return Result.Failure(TicketErrors.TicketNotFound(Id));
        }
        Content = content;
        UpdatedAt = DateTime.UtcNow;
        return Result.Success();
    }
}
