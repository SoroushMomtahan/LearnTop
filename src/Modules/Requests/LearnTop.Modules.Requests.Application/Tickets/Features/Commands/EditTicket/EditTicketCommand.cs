using LearnTop.Modules.Academy.Domain.Tickets.Enums;
using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Academy.Application.Tickets.Commands.EditTicket;

public record EditTicketCommand(
    Guid Id,
    string Title,
    string Content,
    TicketPriority Priority,
    TicketSection Section
    ) : ICommand<EditTicketResponse>;
