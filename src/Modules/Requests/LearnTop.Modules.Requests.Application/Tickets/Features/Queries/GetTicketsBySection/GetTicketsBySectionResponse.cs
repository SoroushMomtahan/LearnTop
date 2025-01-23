using LearnTop.Modules.Requests.Domain.Tickets.ViewModels;
using LearnTop.Shared.Application.Pagination;

namespace LearnTop.Modules.Requests.Application.Tickets.Features.Queries.GetTicketsBySection;

public record GetTicketsBySectionResponse(PaginatedResult<TicketView> PaginatedTicketViews);
