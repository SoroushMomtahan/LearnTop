using LearnTop.Modules.Requests.Application.Tickets.Abstractions;
using LearnTop.Modules.Requests.Domain.Tickets.Errors;
using LearnTop.Modules.Requests.Domain.Tickets.Models;
using LearnTop.Modules.Requests.Domain.Tickets.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Requests.Application.Tickets.Features.Commands.EditReplyTicket;

internal sealed class EditReplyTicketValidation(
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
        ticket.EditReplyTicket(request.ReplyTicketId, )
    }
}
