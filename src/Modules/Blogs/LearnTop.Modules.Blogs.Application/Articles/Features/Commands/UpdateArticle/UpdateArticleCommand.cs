using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Commands.UpdateArticle;

public record UpdateArticleCommand(Guid BlogId, string Title, string Content) : ICommand<UpdateArticleResponse>;
