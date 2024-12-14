using LearnTop.Modules.Academy.Application.Abstractions.Data;
using LearnTop.Modules.Academy.Domain.Tickets.Errors;
using LearnTop.Modules.Academy.Domain.Tickets.Models;
using LearnTop.Modules.Academy.Domain.Tickets.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Academy.Application.Tickets.Commands.EditTicket;

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
            return Result.Failure<EditTicketResponse>(TicketErrors.NotFound(request.Id));
        }
        Result result = ticket.Edit(request.Title, request.Content, request.Priority, request.Section);
        if (result.IsFailure)
        {
            return Result.Failure<EditTicketResponse>(result.Error);
        }
        ticketRepository.Update(ticket);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new EditTicketResponse(ticket.Id);
    }
}
