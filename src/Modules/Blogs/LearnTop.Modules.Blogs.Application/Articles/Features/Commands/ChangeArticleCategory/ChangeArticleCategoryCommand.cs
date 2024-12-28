using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Commands.ChangeArticleCategory;

public record ChangeArticleCategoryCommand(Guid ArticleId, Guid CategoryId)
    : ICommand<ChangeArticleCategoryResponse>;
