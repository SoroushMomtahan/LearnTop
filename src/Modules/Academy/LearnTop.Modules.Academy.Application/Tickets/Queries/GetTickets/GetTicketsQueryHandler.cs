using LearnTop.Modules.Academy.Application.Tickets.Dtos;
using LearnTop.Modules.Academy.Domain.Tickets.Repositories;
using LearnTop.Modules.Academy.Domain.Tickets.ViewModels;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Academy.Application.Tickets.Queries.GetTickets;

public class GetTicketsQueryHandler(
    ITicketViewRepository ticketViewRepository
    ) : IQueryHandler<GetTicketsQuery, GetTicketsQueryResult>
{
    public Task<Result<GetTicketsQueryResult>> Handle(GetTicketsQuery request, CancellationToken cancellationToken)
    {
        int pageIndex = request.PaginationRequest.PageIndex;
        int pageSize = request.PaginationRequest.PageSize;

        List<TicketView> ticketViews = ticketViewRepository.FindAll(pageIndex, pageSize);

        List<TicketDto> ticketDtos = [];
        ticketDtos.AddRange(
            ticketViews
                .Select(
                    ticketView => new TicketDto(
                        ticketView.UserId,
                        ticketView.Title,
                        ticketView.Content,
                        ticketView.Status,
                        ticketView.Priority,
                        ticketView.Section, [])
                    )
            );

        var getTicketsResult = new GetTicketsQueryResult(
            new(pageIndex, pageSize, ticketDtos.Count, ticketDtos)
            );

        return Task.FromResult(Result.Success(getTicketsResult));
    }
}
