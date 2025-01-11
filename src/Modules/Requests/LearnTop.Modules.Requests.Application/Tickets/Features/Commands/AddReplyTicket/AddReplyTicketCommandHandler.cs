using LearnTop.Modules.Academy.Application.Abstractions.Data;
using LearnTop.Modules.Academy.Domain.Tickets.Errors;
using LearnTop.Modules.Academy.Domain.Tickets.Models;
using LearnTop.Modules.Academy.Domain.Tickets.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Academy.Application.Tickets.Commands.AddReplyTicket;

internal sealed class AddReplyTicketCommandHandler(
    ITicketRepository ticketRepository,
    IUnitOfWork unitOfWork
    ) : ICommandHandler<AddReplyTicketCommand, AddReplyTicketResponse>
{

    public async Task<Result<AddReplyTicketResponse>> Handle(AddReplyTicketCommand request, CancellationToken cancellationToken)
    {
        Result<ReplyTicket> result = ReplyTicket.CreateReplyTicket(request.UserId, request.TicketId, request.Content);
        if (result.IsFailure)
        {
            return Result.Failure<AddReplyTicketResponse>(result.Error);
        }
        Ticket? ticket = await ticketRepository.GetByIdAsync(result.Value.TicketId, cancellationToken);
        if (ticket is null)
        {
            return Result.Failure<AddReplyTicketResponse>(TicketErrors.NotFound(result.Value.TicketId));
        }
        await ticketRepository.AddReplyTicketAsync(result.Value);
        ticket.AddReplyTicket(result.Value);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new AddReplyTicketResponse(result.Value.Id);
    }
}
