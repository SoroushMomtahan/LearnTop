using LearnTop.Modules.Requests.Application.Abstractions;
using LearnTop.Modules.Requests.Domain.Tickets.Errors;
using LearnTop.Modules.Requests.Domain.Tickets.Models;
using LearnTop.Modules.Requests.Domain.Tickets.Repositories;
using LearnTop.Modules.Users.PublicApi;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LearnTop.Modules.Requests.Application.Tickets.Features.Commands.AddReplyTicket;

internal sealed class AddReplyTicketCommandHandler(
    ITicketRepository ticketRepository,
    IUnitOfWork unitOfWork,
    IUsersApi usersApi) : ICommandHandler<AddReplyTicketCommand, AddReplyTicketResponse>
{

    public async Task<Result<AddReplyTicketResponse>> Handle(AddReplyTicketCommand request, CancellationToken cancellationToken)
    {
        bool isUserExist = await usersApi.IsExistAsync(request.UserId);
        if (!isUserExist)
        {
            return Result.Failure<AddReplyTicketResponse>(TicketErrors.UserNotFound(request.UserId));
        }

        Ticket? ticket = await ticketRepository.GetByIdAsync(request.TicketId, cancellationToken);
        if (ticket is null)
        {
            return Result.Failure<AddReplyTicketResponse>(TicketErrors.TicketNotFound(request.TicketId));
        }
        
        Result<ReplyTicket> replyTicketResult = ticket.AddReplyTicket(request.UserId, request.Content);
        if (replyTicketResult.IsFailure)
        {
            return Result.Failure<AddReplyTicketResponse>(replyTicketResult.Error);
        }
        
        await ticketRepository.AddAsync(replyTicketResult.Value);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return new AddReplyTicketResponse(request.TicketId);
    }
}
