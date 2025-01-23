using LearnTop.Modules.Requests.Domain.Tickets.Enums;
using LearnTop.Modules.Requests.Domain.Tickets.ViewModels;
using LearnTop.Shared.Application.Pagination;

namespace LearnTop.Modules.Requests.Application.Tickets.Features.Queries.GetTicketsByStatus;

public record GetTicketsByStatusResponse(PaginatedResult<TicketView> PaginatedTicketViews);
