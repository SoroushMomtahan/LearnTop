using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Commands.DeleteArticle;

public record DeleteArticleCommand(Guid ArticleId, bool IsSoftDelete = true) : ICommand<DeleteArticleResponse>;
