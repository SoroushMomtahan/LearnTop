using FluentValidation;

namespace LearnTop.Modules.Users.Application.Users.Features.Commands;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(static u => u.Firstname)
            .Length(3, 50).WithMessage("First name must be between 3 and 50 characters.");
    }
}
