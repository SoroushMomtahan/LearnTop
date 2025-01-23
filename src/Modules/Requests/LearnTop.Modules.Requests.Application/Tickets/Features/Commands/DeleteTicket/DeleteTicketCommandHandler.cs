using LearnTop.Modules.Requests.Application.Abstractions;
using LearnTop.Modules.Requests.Domain.Tickets.Errors;
using LearnTop.Modules.Requests.Domain.Tickets.Models;
using LearnTop.Modules.Requests.Domain.Tickets.Repositories;
using LearnTop.Modules.Requests.Domain.Tickets.Repositories.Views;
using LearnTop.Modules.Requests.Domain.Tickets.ViewModels;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Application.Exceptions;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Requests.Application.Tickets.Features.Commands.DeleteTicket;

internal sealed class DeleteTicketCommandHandler(
    ITicketRepository ticketRepository,
    ITicketViewRepository ticketViewRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<DeleteTicketCommand, DeleteTicketResponse>
{

    public async Task<Result<DeleteTicketResponse>> Handle(
        DeleteTicketCommand request,
        CancellationToken cancellationToken)
    {
        Ticket? ticket = await ticketRepository.GetByIdAsync(request.TicketId, cancellationToken);
        if (ticket is null)
        {
            return Result.Failure<DeleteTicketResponse>(
                TicketErrors.TicketNotFound(request.TicketId)
                );
        }
        if (request.IsSoftDelete)
        {
            ticket.SoftDelete();
        }
        else
        {
            ticketRepository.Delete(ticket);
            await DeleteTicketView(request.TicketId);
        }
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new DeleteTicketResponse(request.TicketId);
    }
    private async Task DeleteTicketView(Guid ticketId)
    {
        TicketView? ticketView = await ticketViewRepository.GetAsync(ticketId);
        if (ticketView is null)
        {
            throw new LearnTopException(nameof(DeleteTicketCommandHandler));
        }
        ticketViewRepository.Delete(ticketView);
        await ticketViewRepository.SaveChangesAsync();
    }
}
