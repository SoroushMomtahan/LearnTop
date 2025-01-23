using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Requests.Application.Tickets.Features.Commands.DeleteReplyTicket;

public sealed record DeleteReplyTicketCommand(Guid TicketId, Guid ReplyTicketId) : ICommand<DeleteReplyTicketResponse>;
