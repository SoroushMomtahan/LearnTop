using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Users.Application.Users.Features.Commands.SendConfirmationEmail;

public record SendConfirmationEmailCommand(string Email) 
    : ICommand<SendConfirmationEmailResponse>;
