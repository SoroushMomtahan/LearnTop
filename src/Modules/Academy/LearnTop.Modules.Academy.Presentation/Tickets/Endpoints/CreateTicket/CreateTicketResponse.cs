using LearnTop.Modules.Academy.Application.Tickets.Commands.CreateTicket;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Academy.Presentation.Tickets.Endpoints.CreateTicket;

internal sealed record CreateTicketResponse(Result<CreateTicketResult> Result);
