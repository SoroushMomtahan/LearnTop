using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Application.Pagination;

namespace LearnTop.Modules.Academy.Application.Tickets.Queries.GetTickets;

public sealed record GetTicketsQuery(PaginationRequest PaginationRequest) : IQuery<GetTicketsQueryResult>;
