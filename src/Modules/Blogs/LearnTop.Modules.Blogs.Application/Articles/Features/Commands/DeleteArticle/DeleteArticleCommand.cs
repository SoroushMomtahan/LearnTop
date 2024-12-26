using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Commands.DeleteArticle;

public record DeleteArticleCommand(Guid BlogId, bool IsLogicDelete) : ICommand<DeleteArticleResponse>;
