using LearnTop.Modules.Requests.Domain.Tickets.Enums;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Application.Pagination;

namespace LearnTop.Modules.Requests.Application.Tickets.Features.Queries.GetTicketsByPriority;

public record GetTicketsByPriorityQuery(
    PaginationRequest PaginationRequest, 
    TicketPriority Priority)
    : IQuery<GetTicketsByPriorityResponse>;
