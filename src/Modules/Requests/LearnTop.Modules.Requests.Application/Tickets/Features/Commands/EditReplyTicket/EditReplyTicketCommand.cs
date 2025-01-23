using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Requests.Application.Tickets.Features.Commands.EditReplyTicket;

public sealed record EditReplyTicketCommand(
    Guid TicketId, 
    Guid ReplyTicketId,
    string Content)
    : ICommand<EditReplyTicketResponse>;
