using FluentValidation;
using LearnTop.Modules.Requests.Domain.Tickets.Errors;

namespace LearnTop.Modules.Requests.Application.Tickets.Features.Commands.AddReplyTicket;

internal sealed class AddReplyTicketValidation : AbstractValidator<AddReplyTicketCommand>
{
    public AddReplyTicketValidation()
    {
        RuleFor(x => x.Content)
            .MinimumLength(3)
            .WithMessage(TicketErrors.ContentLessThan3Character.Description);
    }
}
