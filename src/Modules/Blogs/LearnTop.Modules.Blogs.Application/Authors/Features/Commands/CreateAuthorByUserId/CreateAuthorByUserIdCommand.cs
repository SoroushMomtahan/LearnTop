using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Blogs.Application.Authors.Features.Commands.CreateAuthorByUserId;

public record CreateAuthorByUserIdCommand(
    Guid UserId,
    string Username,
    string? DisplayName) : ICommand;
