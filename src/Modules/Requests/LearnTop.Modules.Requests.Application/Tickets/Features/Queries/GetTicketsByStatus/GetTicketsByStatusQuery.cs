using LearnTop.Modules.Requests.Domain.Tickets.Enums;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Application.Pagination;

namespace LearnTop.Modules.Requests.Application.Tickets.Features.Queries.GetTicketsByStatus;

public record GetTicketsByStatusQuery(
    PaginationRequest PaginationRequest, 
    TicketStatus Status) : IQuery<GetTicketsByStatusResponse>;
