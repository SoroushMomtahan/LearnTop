using LearnTop.Modules.Requests.Application.Tickets.Features.Queries.GetTicketsByPriority;
using LearnTop.Modules.Requests.Application.Tickets.Features.Queries.GetTicketsBySearch;
using LearnTop.Modules.Requests.Application.Tickets.Features.Queries.GetTicketsByStatus;
using LearnTop.Modules.Requests.Domain.Tickets.Repositories.Views;
using LearnTop.Modules.Requests.Domain.Tickets.ViewModels;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Application.Pagination;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Requests.Application.Tickets.Features.Queries.GetTicketsBySection;

internal sealed class GetTicketsBySectionQueryHandler(
    ITicketViewRepository ticketViewRepository) : IQueryHandler<GetTicketsBySectionQuery, GetTicketsBySectionResponse>
{

    public async Task<Result<GetTicketsBySectionResponse>> Handle(GetTicketsBySectionQuery request, CancellationToken cancellationToken)
    {
        int pageIndex = request.PaginationRequest.PageIndex;
        int pageSize = request.PaginationRequest.PageSize;
        long totalCount = await ticketViewRepository.GetTotalCountAsync();
        
        List<TicketView> ticketViews = await ticketViewRepository
            .GetBySectionAsync(request.Section, pageIndex, pageSize);
        PaginatedResult<TicketView> paginatedTicketViews = new
            (
            pageIndex,
            pageSize,
            totalCount,
            ticketViews
            );
        return new GetTicketsBySectionResponse(paginatedTicketViews);
    }
}
