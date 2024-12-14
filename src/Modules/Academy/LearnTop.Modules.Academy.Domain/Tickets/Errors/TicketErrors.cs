using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Academy.Domain.Tickets.Errors;

public static class TicketErrors
{
    public static Error NotFound(Guid ticketId)
    {
        return Error.NotFound("Tickets.NotFound", $"The ticket with the identifier {ticketId} was not found");
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
}
