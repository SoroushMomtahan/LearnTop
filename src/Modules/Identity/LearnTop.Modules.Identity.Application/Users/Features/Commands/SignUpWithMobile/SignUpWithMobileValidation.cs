using FluentValidation;

namespace LearnTop.Modules.Identity.Application.Users.Features.Commands.SignUpWithMobile;

internal sealed class SignUpWithMobileValidation : AbstractValidator<SignUpWithMobileCommand>
{
    public SignUpWithMobileValidation()
    {
        RuleFor(x=>x.Mobile)
            .NotEmpty()
            .Matches(@"^(\+98|0)?9\d{9}$");
        
        RuleFor(x=>x.Password)
            .NotEmpty()
            .MinimumLength(8)
            .MaximumLength(20)
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");
    }
}
