using LearnTop.Modules.Academy.Application.Tickets.Dtos;
using LearnTop.Shared.Application.Pagination;

namespace LearnTop.Modules.Academy.Application.Tickets.Queries.GetTickets;

public sealed record GetTicketsQueryResult(PaginatedResult<TicketDto> TicketDtos);
