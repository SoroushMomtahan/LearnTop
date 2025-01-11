using LearnTop.Shared.Application.Pagination;

namespace LearnTop.Modules.Requests.Application.Tickets.Features.Queries.GetTickets;

public sealed record GetTicketsQueryResponse(PaginatedResult<TicketDto> TicketDtos);
