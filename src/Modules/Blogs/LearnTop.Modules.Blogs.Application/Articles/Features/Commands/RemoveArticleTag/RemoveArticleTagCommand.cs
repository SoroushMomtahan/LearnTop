using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Commands.RemoveArticleTag;

public record RemoveArticleTagCommand(Guid BlogId, Guid TagId)
    : ICommand<RemoveArticleTagResponse>;
