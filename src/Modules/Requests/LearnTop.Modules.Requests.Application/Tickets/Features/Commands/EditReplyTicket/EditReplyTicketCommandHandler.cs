using LearnTop.Modules.Requests.Application.Abstractions;
using LearnTop.Modules.Requests.Domain.Tickets.Errors;
using LearnTop.Modules.Requests.Domain.Tickets.Models;
using LearnTop.Modules.Requests.Domain.Tickets.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Requests.Application.Tickets.Features.Commands.EditReplyTicket;

internal sealed class EditReplyTicketCommandHandler(
    ITicketRepository ticketRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<EditReplyTicketCommand, EditReplyTicketResponse>
{

    public async Task<Result<EditReplyTicketResponse>> Handle(
        EditReplyTicketCommand request, 
        CancellationToken cancellationToken)
    {
        Ticket? ticket = await ticketRepository.GetByIdAsync(request.TicketId, cancellationToken);
        if (ticket is null)
        {
            return Result.Failure<EditReplyTicketResponse>(TicketErrors.TicketNotFound(request.TicketId));
        }
        
        Result validationResult = ticket.EditReplyTicket(request.ReplyTicketId, request.Content);
        if (validationResult.IsFailure)
        {
            return Result.Failure<EditReplyTicketResponse>(validationResult.Error);
        }
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new EditReplyTicketResponse(ticket.Id, request.ReplyTicketId);
    }
}
