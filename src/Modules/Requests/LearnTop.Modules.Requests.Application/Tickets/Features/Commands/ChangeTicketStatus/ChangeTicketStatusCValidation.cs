using FluentValidation;
using LearnTop.Modules.Requests.Domain.Tickets.Errors;

namespace LearnTop.Modules.Requests.Application.Tickets.Features.Commands.ChangeTicketStatus;

internal sealed class ChangeTicketStatusCValidation : AbstractValidator<ChangeTicketStatusCommand>
{
    public ChangeTicketStatusCValidation()
    {
        RuleFor(x=>x.Status)
            .IsInEnum()
            .WithMessage(TicketErrors.StatusOutOfRange.Description);
    }
}
