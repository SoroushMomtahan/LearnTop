using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Requests.Application.Tickets.Features.Commands.AddReplyTicket;

public sealed record AddReplyTicketCommand(
    Guid UserId,
    Guid TicketId,
    string Content) : ICommand<AddReplyTicketResponse>;
