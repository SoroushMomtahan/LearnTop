using LearnTop.Modules.Requests.Application.Abstractions;
using LearnTop.Modules.Requests.Domain.Tickets.Errors;
using LearnTop.Modules.Requests.Domain.Tickets.Models;
using LearnTop.Modules.Requests.Domain.Tickets.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Requests.Application.Tickets.Features.Commands.DeleteReplyTicket;

internal sealed class DeleteReplyTicketCommandHandler(
    ITicketRepository ticketRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<DeleteReplyTicketCommand, DeleteReplyTicketResponse>
{

    public async Task<Result<DeleteReplyTicketResponse>> Handle(
        DeleteReplyTicketCommand request, 
        CancellationToken cancellationToken)
    {
        Ticket? ticket = await ticketRepository
            .GetByIdAsync(request.TicketId,cancellationToken);
        if (ticket is null)
        {
            return Result.Failure<DeleteReplyTicketResponse>(
                TicketErrors.TicketNotFound(request.TicketId)
                );
        }
        Result removeReplyTicketResult = ticket.RemoveReplyTicket(request.TicketId);
        
        if (removeReplyTicketResult.IsFailure)
        {
            return Result.Failure<DeleteReplyTicketResponse>(removeReplyTicketResult.Error);
        }
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new DeleteReplyTicketResponse(ticket.Id, request.TicketId);
    }
}
