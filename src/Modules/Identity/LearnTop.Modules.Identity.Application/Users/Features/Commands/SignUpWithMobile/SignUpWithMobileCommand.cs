using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Identity.Application.Users.Features.Commands.SignUpWithMobile;

public record SignUpWithMobileCommand(
    string Mobile,
    string Password) : ICommand<SignUpWithMobileResponse>;
