using LearnTop.Modules.Requests.Application.Abstractions;
using LearnTop.Modules.Requests.Domain.Tickets.Errors;
using LearnTop.Modules.Requests.Domain.Tickets.Models;
using LearnTop.Modules.Requests.Domain.Tickets.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Requests.Application.Tickets.Features.Commands.ChangeTicketStatus;

internal sealed class ChangeTicketStatusCommandHandler(
    ITicketRepository ticketRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<ChangeTicketStatusCommand, ChangeTicketStatusResponse>
{

    public async Task<Result<ChangeTicketStatusResponse>> Handle(
        ChangeTicketStatusCommand request, 
        CancellationToken cancellationToken)
    {
        Ticket? ticket = await ticketRepository.GetByIdAsync(request.TicketId, cancellationToken);
        if (ticket is null)
        {
            return Result.Failure<ChangeTicketStatusResponse>(
                TicketErrors.TicketNotFound(request.TicketId)
                );
        }
        ticket.ChangeStatus(request.Status);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new ChangeTicketStatusResponse(request.TicketId);
    }
}
