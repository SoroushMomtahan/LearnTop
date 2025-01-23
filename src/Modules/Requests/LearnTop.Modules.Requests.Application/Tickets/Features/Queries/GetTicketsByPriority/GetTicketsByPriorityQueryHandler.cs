using LearnTop.Modules.Requests.Application.Tickets.Features.Queries.GetTicketsBySearch;
using LearnTop.Modules.Requests.Domain.Tickets.Repositories.Views;
using LearnTop.Modules.Requests.Domain.Tickets.ViewModels;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Application.Pagination;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Requests.Application.Tickets.Features.Queries.GetTicketsByPriority;

internal sealed class GetTicketsByPriorityQueryHandler(
    ITicketViewRepository ticketViewRepository)
    : IQueryHandler<GetTicketsByPriorityQuery, GetTicketsByPriorityResponse>
{

    public async Task<Result<GetTicketsByPriorityResponse>> Handle(GetTicketsByPriorityQuery request, CancellationToken cancellationToken)
    {
        int pageIndex = request.PaginationRequest.PageIndex;
        int pageSize = request.PaginationRequest.PageSize;
        bool includeDeletedRows = request.PaginationRequest.IncludeDeletedRows;
        long totalCount = await ticketViewRepository.GetTotalCountAsync();
        
        List<TicketView> ticketViews = await ticketViewRepository
            .GetByPriorityAsync(request.Priority, pageIndex, pageSize, includeDeletedRows);
        PaginatedResult<TicketView> paginatedTicketViews = new
            (
            pageIndex,
            pageSize,
            totalCount,
            ticketViews
            );
        return new GetTicketsByPriorityResponse(paginatedTicketViews);
    }
}
