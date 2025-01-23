using FluentValidation;
using LearnTop.Modules.Requests.Domain.Tickets.Errors;

namespace LearnTop.Modules.Requests.Application.Tickets.Features.Commands.EditTicket;

internal sealed class EditTicketValidation : AbstractValidator<EditTicketCommand>
{
    public EditTicketValidation()
    {
        RuleFor(static t => t.Title)
            .MinimumLength(3)
            .WithMessage(TicketErrors.TitleLessThan3Character.Description)
            .MaximumLength(50)
            .WithMessage(TicketErrors.TitleMoreThan50Character.Description);
        
        RuleFor(static t => t.Content)
            .MinimumLength(3)
            .WithMessage(TicketErrors.ContentLessThan3Character.Description);
        
        RuleFor(t => t.Priority)
            .IsInEnum()
            .WithMessage(TicketErrors.PriorityOutOfRange.Description);
        
        RuleFor(t => t.Section)
            .IsInEnum()
            .WithMessage(TicketErrors.SectionOutOfRange.Description);
    }
}
