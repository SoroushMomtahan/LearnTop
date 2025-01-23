using LearnTop.Modules.Requests.Domain.Tickets.Repositories.Views;
using LearnTop.Modules.Requests.Domain.Tickets.ViewModels;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Requests.Application.Tickets.Features.Queries.GetTickets;

public class GetTicketsQueryHandler(
    ITicketViewRepository ticketViewRepository
    ) : IQueryHandler<GetTicketsQuery, GetTicketsQueryResponse>
{
    public async Task<Result<GetTicketsQueryResponse>> Handle(GetTicketsQuery request, CancellationToken cancellationToken)
    {
        int pageIndex = request.PaginationRequest.PageIndex;
        int pageSize = request.PaginationRequest.PageSize;
        long totalCount = await ticketViewRepository.GetTotalCountAsync();

        List<TicketView> ticketViews = await ticketViewRepository.GetAsync(pageIndex, pageSize);
        
        var paginatedTicketViews = new GetTicketsQueryResponse(
            new(pageIndex, pageSize, totalCount, ticketViews)
            );

        return paginatedTicketViews;
    }
}
