using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Commands.ChangeArticleCategory;

public record ChangeArticleCategoryCommand(Guid BlogId, Guid CategoryId)
    : ICommand<ChangeArticleCategoryResponse>;
