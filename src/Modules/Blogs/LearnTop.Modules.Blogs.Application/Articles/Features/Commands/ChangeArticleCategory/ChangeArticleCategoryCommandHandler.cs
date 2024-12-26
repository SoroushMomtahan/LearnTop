using LearnTop.Modules.Blogs.Domain.Articles.Errors;
using LearnTop.Modules.Blogs.Domain.Articles.Models;
using LearnTop.Modules.Blogs.Domain.Articles.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Commands.ChangeArticleCategory;

public class ChangeArticleCategoryCommandHandler(IArticleRepository articleRepository)
    : ICommandHandler<ChangeArticleCategoryCommand, ChangeArticleCategoryResponse>
{

    public async Task<Result<ChangeArticleCategoryResponse>> Handle(ChangeArticleCategoryCommand request, CancellationToken cancellationToken)
    {
        // TODO: Find Category Wth CategoryId
        
        Article? blog = await articleRepository.GetByIdAsync(request.BlogId);
        if (blog is null)
        {
            return Result.Failure<ChangeArticleCategoryResponse>(ArticleErrors.NotFound(request.BlogId));
        }
        blog.ChangeCategory(request.CategoryId);
        await articleRepository.UpdateAsync(blog);
        return new ChangeArticleCategoryResponse(blog.Id);
    }
}
