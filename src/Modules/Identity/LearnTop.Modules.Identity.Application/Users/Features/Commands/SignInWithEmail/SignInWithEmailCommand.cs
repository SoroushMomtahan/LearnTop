using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Identity.Application.Users.Features.Commands.SignInWithEmail;

public record SignInWithEmailCommand(
    string Email, 
    string Password) : ICommand<SignInWithEmailResponse>;
