using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Blogs.Application.Blogs.Features.Commands.RemoveBlogTag;

public record RemoveBlogTagCommand(Guid BlogId, Guid TagId)
    : ICommand<RemoveBlogTagResponse>;
