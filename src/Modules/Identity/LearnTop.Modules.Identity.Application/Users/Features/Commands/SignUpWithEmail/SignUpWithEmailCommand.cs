using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Identity.Application.Users.Features.Commands.SignUpWithEmail; 
public record SignUpWithEmailCommand(
    string Email, 
    string Password) : ICommand<SignUpWithEmailResponse>;
