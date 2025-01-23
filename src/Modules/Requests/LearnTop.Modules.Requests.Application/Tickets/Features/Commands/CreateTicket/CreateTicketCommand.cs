using LearnTop.Modules.Requests.Domain.Tickets.Enums;
using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Requests.Application.Tickets.Features.Commands.CreateTicket;

public sealed record CreateTicketCommand(
    Guid UserId,
    string Title,
    string Content,
    TicketPriority Priority,
    TicketSection Section
    ) : ICommand<CreateTicketResponse>;
