namespace LearnTop.Modules.Academy.Application.Tickets.Dtos;

public record TicketDto(
    Guid UserId,
    string Title,
    string Content,
    string Status,
    string Priority,
    string Section,
    List<ReplyTicketDto> ReplyTicketDtos
    );
