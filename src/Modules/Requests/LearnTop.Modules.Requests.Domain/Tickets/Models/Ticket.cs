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

    public Result Update(
        string title, 
        string content)
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
        UpdatedAt = DateTime.Now;
        AddDomainEvent(new TicketUpdatedEvent(this));
        return Result.Success();
    }
    public void ChangeStatus(TicketStatus status)
    {
        Status = status;
        AddDomainEvent(new TicketUpdatedEvent(this));
    }
    public void SoftDelete()
    {
        IsDeleted = true;
        DeletedAt = DateTime.Now;
        AddDomainEvent(new TicketUpdatedEvent(this));
    }
    public Result AddReplyTicket(ReplyTicket replyTicket)
    {
        bool exists = _replyTickets.Exists(x=>x.Id == replyTicket.Id);
        if (exists)
        {
            return Result.Failure(TicketErrors.ReplyTicketAlreadyExist(replyTicket.Id));
        }
        if (replyTicket.UserId != UserId)
        {
            Status = TicketStatus.Answered;
        }
        _replyTickets.Add(replyTicket);
        AddDomainEvent(new TicketUpdatedEvent(this));
        return Result.Success();
    }
    public Result RemoveReplyTicket(ReplyTicket replyTicket)
    {
        bool isReplyTicketExist = _replyTickets.Any(r => r.Id == replyTicket.Id);
        if (!isReplyTicketExist)
        {
            return Result.Failure(TicketErrors.ReplyTicketNotFound(replyTicket.Id));
        }
        _replyTickets.Remove(replyTicket);
        AddDomainEvent(new TicketUpdatedEvent(this));
        return Result.Success();
    }
}
