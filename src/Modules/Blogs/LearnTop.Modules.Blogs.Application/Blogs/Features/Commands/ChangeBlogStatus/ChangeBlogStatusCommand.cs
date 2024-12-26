using LearnTop.Modules.Blogs.Domain.Blogs.enums;
using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Blogs.Application.Blogs.Features.Commands.ChangeBlogStatus;

public record ChangeBlogStatusCommand(Guid BlogId, Status Status) : ICommand<ChangeBlogStatusResponse>;
