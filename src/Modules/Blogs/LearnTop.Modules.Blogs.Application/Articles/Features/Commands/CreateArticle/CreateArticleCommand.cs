using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Commands.CreateArticle;

public record CreateArticleCommand(
    Guid AuthorId,
    Guid CategoryId,
    string Title, 
    string Content
    ) : ICommand<CreateArticleResponse>;
