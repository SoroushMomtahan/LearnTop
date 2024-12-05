using FluentValidation;

namespace LearnTop.Modules.Academy.Application.Tickets.Commands.CreateTicket;

internal sealed class CreateTicketCommandValidation : AbstractValidator<CreateTicketCommand>
{
    public CreateTicketCommandValidation()
    {
        RuleFor(static t => t.CreateTicketDto.Content).NotEmpty();
        RuleFor(static t => t.CreateTicketDto.Title)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(20);
    }
}
