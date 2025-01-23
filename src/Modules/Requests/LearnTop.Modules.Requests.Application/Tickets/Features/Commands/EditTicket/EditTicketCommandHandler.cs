using LearnTop.Modules.Requests.Application.Abstractions;
using LearnTop.Modules.Requests.Domain.Tickets.Errors;
using LearnTop.Modules.Requests.Domain.Tickets.Models;
using LearnTop.Modules.Requests.Domain.Tickets.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Requests.Application.Tickets.Features.Commands.EditTicket;

public class EditTicketCommandHandler(
    ITicketRepository ticketRepository,
    IUnitOfWork unitOfWork
    )
    : ICommandHandler<EditTicketCommand, EditTicketResponse>
{

    public async Task<Result<EditTicketResponse>> Handle(EditTicketCommand request, CancellationToken cancellationToken)
    {
        Ticket? ticket = await ticketRepository.GetByIdAsync(request.Id, cancellationToken);
        if (ticket is null)
        {
            return Result.Failure<EditTicketResponse>(TicketErrors.TicketNotFound(request.Id));
        }
        Result result = ticket.Edit(request.Title, request.Content, request.Priority, request.Section);
        if (result.IsFailure)
        {
            return Result.Failure<EditTicketResponse>(result.Error);
        }
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new EditTicketResponse(ticket.Id);
    }
}
