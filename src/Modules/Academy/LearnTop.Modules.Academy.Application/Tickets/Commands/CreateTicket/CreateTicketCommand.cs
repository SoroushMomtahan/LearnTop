using LearnTop.Modules.Academy.Application.Tickets.Dtos;
using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Academy.Application.Tickets.Commands.CreateTicket;

public sealed record CreateTicketCommand(CreateTicketDto CreateTicketDto) : ICommand<CreateTicketResult>
{

}
