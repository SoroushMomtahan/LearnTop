using LearnTop.Modules.Blogs.Application.Abstractions.Data;
using LearnTop.Modules.Blogs.Domain.Aggregates.Articles.Errors;
using LearnTop.Modules.Blogs.Domain.Aggregates.Articles.Models;
using LearnTop.Modules.Blogs.Domain.Aggregates.Articles.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Commands.ChangeArticleCategory;

public class ChangeArticleCategoryCommandHandler
    (IArticleRepository articleRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<ChangeArticleCategoryCommand, ChangeArticleCategoryResponse>
{

    public async Task<Result<ChangeArticleCategoryResponse>> Handle(ChangeArticleCategoryCommand request, CancellationToken cancellationToken)
    {
        // TODO: Find Category Wth CategoryId
        
        Article? article = await articleRepository.GetByIdAsync(request.ArticleId);
        if (article is null)
        {
            return Result.Failure<ChangeArticleCategoryResponse>(ArticleErrors.NotFound(request.ArticleId));
        }
        article.ChangeCategory(request.CategoryId);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new ChangeArticleCategoryResponse(article.Id);
    }
}
