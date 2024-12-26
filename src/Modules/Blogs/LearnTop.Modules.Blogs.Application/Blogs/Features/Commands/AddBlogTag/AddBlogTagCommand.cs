using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Blogs.Application.Blogs.Features.Commands.AddBlogTag;

public record AddBlogTagCommand(Guid BlogId, Guid TagId)
    : ICommand<AddBlogTagResponse>;
