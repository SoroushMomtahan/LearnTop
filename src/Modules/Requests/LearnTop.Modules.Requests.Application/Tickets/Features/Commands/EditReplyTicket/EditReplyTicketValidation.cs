using FluentValidation;
using LearnTop.Modules.Requests.Domain.Tickets.Errors;

namespace LearnTop.Modules.Requests.Application.Tickets.Features.Commands.EditReplyTicket;

internal sealed class EditReplyTicketValidation : AbstractValidator<EditReplyTicketCommand>
{
    public EditReplyTicketValidation()
    {
        RuleFor(x => x.Content)
            .MinimumLength(3)
            .WithMessage(TicketErrors.ContentLessThan3Character.Description);
    }
}
