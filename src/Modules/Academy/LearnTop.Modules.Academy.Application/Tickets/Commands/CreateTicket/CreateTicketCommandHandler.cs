using LearnTop.Modules.Academy.Domain.Tickets.Models;
using LearnTop.Modules.Academy.Domain.Tickets.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Application.Data;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Academy.Application.Tickets.Commands.CreateTicket;

internal sealed class CreateTicketCommandHandler
    (ITicketRepository ticketRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreateTicketCommand, CreateTicketResult>
{
    public async Task<Result<CreateTicketResult>> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        Result<Ticket> result = Ticket.CreateTicket(
            request.CreateTicketDto.UserId,
            request.CreateTicketDto.Title,
            request.CreateTicketDto.Content,
            request.CreateTicketDto.Priority,
            request.CreateTicketDto.Section
            );
        await ticketRepository.AddAsync(result.Value);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(new CreateTicketResult(result.Value.Id));
    }
}
