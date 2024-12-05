using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Users.Application.Users.Commands;

public record CreateUserCommand
    (string Firstname, string Lastname, string Email, string Password)
    : ICommand<CreateUserCommandResponse>;
