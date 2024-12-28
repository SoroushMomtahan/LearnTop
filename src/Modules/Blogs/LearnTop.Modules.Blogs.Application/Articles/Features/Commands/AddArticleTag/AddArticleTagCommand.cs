using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Commands.AddArticleTag;

public record AddArticleTagCommand(Guid ArticleId, Guid TagId)
    : ICommand<AddArticleTagResponse>;
