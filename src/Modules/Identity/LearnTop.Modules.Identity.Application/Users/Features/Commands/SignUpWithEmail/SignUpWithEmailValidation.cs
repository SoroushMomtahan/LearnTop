using FluentValidation;

namespace LearnTop.Modules.Identity.Application.Users.Features.Commands.SignUpWithEmail;

internal sealed class SignUpWithEmailValidation : AbstractValidator<SignUpWithEmailCommand>
{
    public SignUpWithEmailValidation()
    {
        RuleFor(x=>x.Email)
            .NotEmpty()
            .EmailAddress();
        
        RuleFor(x=>x.Password)
            .NotEmpty()
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");
    }
}
