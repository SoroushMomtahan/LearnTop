using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Application.Pagination;

namespace LearnTop.Modules.Requests.Application.Tickets.Features.Queries.GetTickets;

public sealed record GetTicketsQuery(PaginationRequest PaginationRequest) : IQuery<GetTicketsQueryResponse>;
