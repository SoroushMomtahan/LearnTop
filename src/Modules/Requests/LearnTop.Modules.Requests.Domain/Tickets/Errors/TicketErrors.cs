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
    public static readonly Error TitleMoreThan50Character = Error.Validation(
        "Ticket.TitleMoreThan50Character",
        "عنوان نمی تواند کمتر از 50 کاراکتر باشد.");

    public static readonly Error ContentLessThan3Character = Error.Validation(
        "Ticket.ContentLessThan3Character",
        "محتوای تیکت نمی تواند کمتر از 3 کاراکتر باشد.");
    public static readonly Error PriorityOutOfRange = Error.Validation(
        "Ticket.PriorityOutOfRange",
        "مقدار وارد شده برای فیلد اولویت خارج از بازه مجاز است.");
    public static readonly Error SectionOutOfRange = Error.Validation(
        "Ticket.SectionOutOfRange",
        "مقدار وارد شده برای فیلد بخش خارج از بازه مجاز است.");
    public static readonly Error StatusOutOfRange = Error.Validation(
        "Ticket.StatusOutOfRange",
        "مقدار وارد شده برای فیلد وضعیت خارج از بازه مجاز است.");
    public static Error ReplyTicketAlreadyExist(Guid replyTicketId)
    {
        return Error.Conflict(
            "Tickets.ReplyTicketAlreadyExist", $"پاسخ تیکت با شناسه {replyTicketId} از قبل وجود دارد.");
    }
    public static Error ConcurrencyConflict()
    {
        return Error.Conflict(
            "Tickets.ConcurrencyConflict",
            "مشکل همزمانی رخ داد.");
    }
}
