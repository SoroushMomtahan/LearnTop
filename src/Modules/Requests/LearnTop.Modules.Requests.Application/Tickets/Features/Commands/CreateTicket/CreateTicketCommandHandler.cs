using LearnTop.Modules.Academy.Application.Abstractions.Data;
using LearnTop.Modules.Academy.Domain.Tickets.Errors;
using LearnTop.Modules.Academy.Domain.Tickets.Models;
using LearnTop.Modules.Academy.Domain.Tickets.Repositories;
using LearnTop.Modules.Users.PublicApi;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Academy.Application.Tickets.Commands.CreateTicket;

internal sealed class CreateTicketCommandHandler
    (ITicketRepository ticketRepository,
    IUnitOfWork unitOfWork,
    IUsersApi usersApi)
    : ICommandHandler<CreateTicketCommand, CreateTicketResponse>
{
    public async Task<Result<CreateTicketResponse>> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        Guid userId = request.CreateTicketDto.UserId;
        bool isExist = await usersApi.IsExistAsync(userId);
        if (!isExist)
        {
            return Result.Failure<CreateTicketResponse>(TicketErrors.UserNotFound(userId));
        }
        Result<Ticket> result = Ticket.CreateTicket(
            userId,
            request.CreateTicketDto.Title,
            request.CreateTicketDto.Content,
            request.CreateTicketDto.Priority,
            request.CreateTicketDto.Section
            );
        if (!result.IsSuccess)
        {
            return Result.Failure<CreateTicketResponse>(result.Error);
        }
        await ticketRepository.AddAsync(result.Value);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success(new CreateTicketResponse(result.Value.Id));
    }
}
