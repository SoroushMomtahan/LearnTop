using FluentValidation;
using LearnTop.Modules.Users.Domain.Users.Errors;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Users.Application.Users.Features.Commands.CreateUser;

internal sealed class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x=>x.Password)
            .NotEmpty()
            .WithMessage(Error.Empty("کلمه عبور").Description);
        RuleFor(x => x.ConfirmPassword)
            .Equal(x => x.Password)
            .NotEmpty()
            .WithMessage(UserErrors.PasswordsNotEqual.Description);
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage(UserErrors.EmailNotValid.Description);
    }
}
