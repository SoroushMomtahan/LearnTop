using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Application.Pagination;

namespace LearnTop.Modules.Requests.Application.Tickets.Features.Queries.GetTicketsBySearch;

public record GetTicketsBySearchQuery(PaginationRequest PaginationRequest, string SearchString)
    : IQuery<GetTicketsBySearchResponse>;
