using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Commands.CreatePrivateArticle;

public record CreatePrivateArticleCommand(Guid AuthorId) : ICommand<CreatePrivateArticleCommand.Response>
{
    public record Response(Guid ArticleId);
}
