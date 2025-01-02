using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Users.Application.Users.Features.Commands.CreateUser;

public record CreateUserCommand
    (string Email, string Password, string ConfirmPassword)
    : ICommand<CreateUserResponse>;
