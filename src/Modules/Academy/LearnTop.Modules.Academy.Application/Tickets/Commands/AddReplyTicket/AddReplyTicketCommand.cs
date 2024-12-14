using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Academy.Application.Tickets.Commands.AddReplyTicket;

public sealed record AddReplyTicketCommand(
    Guid UserId,
    Guid TicketId,
    string Content) : ICommand<AddReplyTicketResponse>;
