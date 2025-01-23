using LearnTop.Modules.Requests.Domain.Tickets.Enums;
using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Requests.Application.Tickets.Features.Commands.EditTicket;

public record EditTicketCommand(
    Guid Id,
    string Title,
    string Content,
    TicketPriority Priority,
    TicketSection Section
    ) : ICommand<EditTicketResponse>;
