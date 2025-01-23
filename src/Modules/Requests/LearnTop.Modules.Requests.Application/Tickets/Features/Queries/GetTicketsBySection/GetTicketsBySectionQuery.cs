using LearnTop.Modules.Requests.Domain.Tickets.Enums;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Application.Pagination;

namespace LearnTop.Modules.Requests.Application.Tickets.Features.Queries.GetTicketsBySection;

public record GetTicketsBySectionQuery(
    PaginationRequest PaginationRequest,
    TicketSection Section) 
    : IQuery<GetTicketsBySectionResponse>;
