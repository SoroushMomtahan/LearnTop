using LearnTop.Modules.Requests.Application.Tickets.Features.Queries.GetTicketsBySearch;
using LearnTop.Modules.Requests.Domain.Tickets.Repositories.Views;
using LearnTop.Modules.Requests.Domain.Tickets.ViewModels;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Application.Pagination;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Requests.Application.Tickets.Features.Queries.GetTicketsByStatus; 

internal sealed class GetTicketsByStatusQueryHandler(
    ITicketViewRepository ticketViewRepository)
    : IQueryHandler<GetTicketsByStatusQuery, GetTicketsByStatusResponse>
{

    public async Task<Result<GetTicketsByStatusResponse>> Handle(GetTicketsByStatusQuery request, CancellationToken cancellationToken)
    {
        int pageIndex = request.PaginationRequest.PageIndex;
        int pageSize = request.PaginationRequest.PageSize;
        bool includeDeletedRows = request.PaginationRequest.IncludeDeletedRows;
        long totalCount = await ticketViewRepository.GetTotalCountAsync();
        
        List<TicketView> ticketViews = await ticketViewRepository
            .GetByStatusAsync(request.Status, pageIndex, pageSize, includeDeletedRows);
        
        PaginatedResult<TicketView> pagedTicketViews = 
            new(pageIndex, pageSize, totalCount, ticketViews);
        
        return new GetTicketsByStatusResponse(pagedTicketViews);
    }
}
