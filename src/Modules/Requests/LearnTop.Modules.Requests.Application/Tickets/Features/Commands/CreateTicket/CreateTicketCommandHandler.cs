using LearnTop.Modules.Requests.Application.Abstractions;
using LearnTop.Modules.Requests.Domain.Tickets.Errors;
using LearnTop.Modules.Requests.Domain.Tickets.Models;
using LearnTop.Modules.Requests.Domain.Tickets.Repositories;
using LearnTop.Modules.Users.PublicApi;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Requests.Application.Tickets.Features.Commands.CreateTicket;

internal sealed class CreateTicketCommandHandler
    (ITicketRepository ticketRepository,
    IUnitOfWork unitOfWork,
    IUsersApi usersApi)
    : ICommandHandler<CreateTicketCommand, CreateTicketResponse>
{
    public async Task<Result<CreateTicketResponse>> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        Guid userId = request.UserId;
        bool isExist = await usersApi.IsExistAsync(userId);
        if (!isExist)
        {
            return Result.Failure<CreateTicketResponse>(TicketErrors.UserNotFound(userId));
        }
        Result<Ticket> result = Ticket.CreateTicket(
            userId,
            request.Title,
            request.Content,
            request.Priority,
            request.Section
            );
        if (result.IsFailure)
        {
            return Result.Failure<CreateTicketResponse>(result.Error);
        }
        await ticketRepository.AddAsync(result.Value);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new CreateTicketResponse(result.Value.Id);
    }
}
