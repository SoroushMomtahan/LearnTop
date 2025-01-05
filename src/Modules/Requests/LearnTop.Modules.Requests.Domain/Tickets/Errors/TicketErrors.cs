using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Requests.Domain.Tickets.Errors;

public static class TicketErrors
{
    public static Error TicketNotFound(Guid ticketId)
    {
        return Error.NotFound("Tickets.TicketNotFound", $"تیکتی با شناسه {ticketId} یافت نشد.");
    }
    public static Error ReplyTicketNotFound(Guid replyTicket)
    {
        return Error.NotFound("Tickets.ReplyTicketNotFound", $"پاسخی با شناسه {replyTicket} یافت نشد.");
    }
    public static Error UserNotFound(Guid userId)
    {
        return Error.NotFound("Tickets.UserNotFound", $"The user with the identifier {userId} was not found");
    }

    public static readonly Error TitleLessThan3Character = Error.Validation(
        "Ticket.TitleLessThan3Character",
        "عنوان نمی تواند کمتر از 3 کاراکتر باشد.");

    public static readonly Error ContentLessThan3Character = Error.Validation(
        "Ticket.ContentLessThan3Character",
        "محتوای تیکت نمی تواند کمتر از 3 کاراکتر باشد.");
    public static Error ReplyTicketAlreadyExist(Guid replyTicketId)
    {
        return Error.Conflict(
            "Tickets.ReplyTicketAlreadyExist", $"پاسخ تیکت با شناسه {replyTicketId} از قبل وجود دارد.");
    }
}
