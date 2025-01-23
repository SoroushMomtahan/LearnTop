using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Requests.Application.Tickets.Features.Commands.DeleteTicket;

public record DeleteTicketCommand(Guid TicketId, bool IsSoftDelete) : ICommand<DeleteTicketResponse>;
