using LearnTop.Modules.Requests.Domain.Tickets.Enums;
using LearnTop.Modules.Requests.Domain.Tickets.Errors;
using LearnTop.Modules.Requests.Domain.Tickets.Events;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Requests.Domain.Tickets.Models;

public class Ticket : Aggregate
{
    public Guid UserId { get; private set; }
    public string Title { get; private set; }
    public string Content { get; private set; }
    public bool IsDeleted { get; private set; }
    public TicketStatus Status { get; private set; }
    public TicketPriority Priority { get; private set; }
    public TicketSection Section { get; private set; }

    private readonly List<ReplyTicket> _replyTickets = [];
    public IReadOnlyList<ReplyTicket> ReplyTickets => [.. _replyTickets];

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
#pragma warning disable S125
            // return Result.ValidationFailure1<Ticket>(TicketErrors.TitleLessThan3Character);
#pragma warning disable S125
        }
        if (content.Length < 3)
        {
#pragma warning disable S125
            // return Result.ValidationFailure1<Ticket>(TicketErrors.ContentLessThan3Character);
#pragma warning disable S125
        }
        var ticket = new Ticket(userId, title, content, TicketStatus.Open, priority, section);
        ticket.AddDomainEvent(new TicketCreatedEvent(ticket));
        return ticket;
    }

    public Result Edit(
        string title, 
        string content,
        TicketPriority priority,
        TicketSection section)
    {
        if (title.Length < 3)
        {
#pragma warning disable S125
            // return Result.ValidationFailure1<Ticket>(TicketErrors.TitleLessThan3Character);
#pragma warning disable S125
        }
        if (content.Length < 3)
        {
#pragma warning disable S125
            // return Result.ValidationFailure1<Ticket>(TicketErrors.ContentLessThan3Character);
#pragma warning disable S125
        }

        Title = title;
        Content = content;
        Priority = priority;
        Section = section;
        UpdatedAt = DateTime.Now;
        AddDomainEvent(new TicketUpdatedEvent(this));
        return Result.Success();
    }
    public void ChangeStatus(TicketStatus status)
    {
        Status = status;
        UpdatedAt = DateTime.Now;
        AddDomainEvent(new TicketUpdatedEvent(this));
    }
    public void SoftDelete()
    {
        IsDeleted = true;
        UpdatedAt = DateTime.Now;
        DeletedAt = DateTime.Now;
        AddDomainEvent(new TicketUpdatedEvent(this));
    }
    public Result<ReplyTicket> AddReplyTicket(Guid userId, string content)
    {
        Result<ReplyTicket> replyTicketResult = ReplyTicket.Create(userId, content);
        if (replyTicketResult.IsFailure)
        {
            return Result.Failure<ReplyTicket>(replyTicketResult.Error);
        }
        if (userId != UserId)
        {
            Status = TicketStatus.Answered;
        }
        _replyTickets.Add(replyTicketResult.Value);
        UpdatedAt = DateTime.Now;
        AddDomainEvent(new TicketUpdatedEvent(this));
        return replyTicketResult.Value;
    }
    public Result RemoveReplyTicket(Guid replyTicketId)
    {
        ReplyTicket replyTicket = _replyTickets.Find(r => r.Id == replyTicketId);
        if (replyTicket is null)
        {
            return Result.Failure(TicketErrors.ReplyTicketNotFound(replyTicketId));
        }
        _replyTickets.Remove(replyTicket);
        UpdatedAt = DateTime.Now;
        AddDomainEvent(new TicketUpdatedEvent(this));
        return Result.Success();
    }
    public Result EditReplyTicket(Guid replyTicketId, string content)
    {
        ReplyTicket? replyTicket = _replyTickets.Find(x => x.Id == replyTicketId);
        if (replyTicket is null)
        {
            return Result.Failure(TicketErrors.ReplyTicketNotFound(replyTicketId));
        }
        Result result = replyTicket.Edit(content);
        if (result.IsFailure)
        {
            return Result.Failure(result.Error);
        }
        UpdatedAt = DateTime.Now;
        AddDomainEvent(new TicketUpdatedEvent(this));
        return Result.Success();
    }
}
