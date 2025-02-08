using LearnTop.Modules.Requests.Domain.Tickets.Repositories.Views;
using LearnTop.Modules.Requests.Domain.Tickets.ViewModels;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Application.Pagination;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Requests.Application.Tickets.Features.Queries.GetTicketsBySearch;

internal sealed class GetTicketsBySearchQueryHandler(
    ITicketViewRepository ticketViewRepository)
    : IQueryHandler<GetTicketsBySearchQuery, GetTicketsBySearchResponse>
{

    public async Task<Result<GetTicketsBySearchResponse>> Handle(GetTicketsBySearchQuery request, CancellationToken cancellationToken)
    {
        int pageIndex = request.PaginationRequest.PageIndex;
        int pageSize = request.PaginationRequest.PageSize;
        long totalCount = await ticketViewRepository.GetTotalCountAsync();
        
        List<TicketView> ticketViews = await ticketViewRepository
            .GetBySearchAsync(request.SearchString, pageIndex, pageSize);
        PaginatedResult<TicketView> paginatedTicketViews = new
            (
            pageIndex,
            pageSize,
            totalCount,
            ticketViews
            );
        return new GetTicketsBySearchResponse(paginatedTicketViews);
    }
}
