using LearnTop.Modules.Academy.Domain.Tickets.Enums;
using LearnTop.Modules.Academy.Domain.Tickets.Errors;
using LearnTop.Modules.Academy.Domain.Tickets.Events;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Academy.Domain.Tickets.Models;

public class Ticket : Aggregate
{
    public Guid UserId { get; private set; }
    public string Title { get; private set; }
    public string Content { get; private set; }
    public TicketStatus Status { get; private set; }
    public TicketPriority Priority { get; private set; }
    public TicketSection Section { get; private set; }

    private readonly List<ReplyTicket> _replyTickets = [];
    public IReadOnlyList<ReplyTicket> ReplyTickets => _replyTickets.AsReadOnly();

    private Ticket() { }

    private Ticket(
        Guid userId,
        string title,
        string content,
        TicketStatus status,
        TicketPriority priority,
        TicketSection section)
    {
        UserId = userId;
        Title = title;
        Content = content;
        Status = status;
        Priority = priority;
        Section = section;
    }

    public static Result<Ticket> CreateTicket(
        Guid userId,
        string title,
        string content,
        TicketPriority priority,
        TicketSection section)
    {
        if (title.Length < 3)
        {
            return Result.ValidationFailure<Ticket>(TicketErrors.TitleLessThan3Character);
        }
        if (content.Length < 3)
        {
            return Result.ValidationFailure<Ticket>(TicketErrors.ContentLessThan3Character);
        }
        var ticket = new Ticket(userId, title, content, TicketStatus.Open, priority, section);
        ticket.AddDomainEvent(new TicketCreatedEvent(ticket));
        return ticket;
    }

    public Result Edit(string title, string content, TicketPriority priority,
        TicketSection section)
    {
        if (title.Length < 3)
        {
            return Result.ValidationFailure<Ticket>(TicketErrors.TitleLessThan3Character);
        }
        if (content.Length < 3)
        {
            return Result.ValidationFailure<Ticket>(TicketErrors.ContentLessThan3Character);
        }

        Title = title;
        Content = content;
        Priority = priority;
        Section = section;
        UpdatedAt = DateTime.Now;

        return Result.Success();
    }

    public void AddReplyTicket(ReplyTicket replyTicket)
    {
        if (replyTicket.UserId != UserId)
        {
            Status = TicketStatus.Answered;
        }
        _replyTickets.Add(replyTicket);
    }

    public void ChangeStatus(TicketStatus status)
    {
        Status = status;
    }

    public Result RemoveReplyTicket(ReplyTicket replyTicket)
    {
        bool isReplyTicketExist = _replyTickets.Any(r => r.Id == replyTicket.Id);
        if (!isReplyTicketExist)
        {
            return Result.Failure(ReplyTicketErrors.NotFound(replyTicket.Id));
        }
        _replyTickets.Remove(replyTicket);
        return Result.Success();
    }
}
