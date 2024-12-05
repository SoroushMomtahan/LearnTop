using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Academy.Domain.Tickets.Errors;

public static class ReplyTicketErrors
{
    public static Error NotFound(Guid id)
    {
        return new Error("Tickets.NotFound", $"پاسخی با شناسه {id} برای تیکت مورد نظر یافت نشد.", ErrorType.NotFound);
    }
}
