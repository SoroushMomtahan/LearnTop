using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Identity.Application.Users.Features.Commands.GenerateEmailCode;

public record GenerateEmailCodeCommand(string Email) 
    : ICommand<GenerateEmailCodeResponse>;
