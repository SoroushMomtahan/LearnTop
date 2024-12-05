using LearnTop.Modules.Academy.Domain.Tickets.Enums;

namespace LearnTop.Modules.Academy.Application.Tickets.Dtos;

public record CreateTicketDto
    (
        Guid UserId,
        string Title,
        string Content,
        TicketPriority Priority,
        TicketSection Section
        );
