using LearnTop.Modules.Requests.Domain.Tickets.ViewModels;
using LearnTop.Shared.Application.Pagination;

namespace LearnTop.Modules.Requests.Application.Tickets.Features.Queries.GetTicketsByPriority;

public record GetTicketsByPriorityResponse(PaginatedResult<TicketView> PaginatedTicketViews);
