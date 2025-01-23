using System.Windows.Input;
using LearnTop.Modules.Requests.Domain.Tickets.Enums;
using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Requests.Application.Tickets.Features.Commands.ChangeTicketStatus;

public sealed record ChangeTicketStatusCommand(Guid TicketId, TicketStatus Status) : ICommand<ChangeTicketStatusResponse>;
