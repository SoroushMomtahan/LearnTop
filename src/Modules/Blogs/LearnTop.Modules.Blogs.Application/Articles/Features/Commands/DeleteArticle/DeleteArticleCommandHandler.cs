using LearnTop.Modules.Blogs.Application.Abstractions.Data;
using LearnTop.Modules.Blogs.Domain.Articles.Errors;
using LearnTop.Modules.Blogs.Domain.Articles.Models;
using LearnTop.Modules.Blogs.Domain.Articles.Repositories;
using LearnTop.Modules.Blogs.Domain.Articles.Views;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Application.Exceptions;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Commands.DeleteArticle;

public class DeleteArticleCommandHandler
    (IArticleRepository articleRepository,
    IArticleViewRepository articleViewRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<DeleteArticleCommand, DeleteArticleResponse>
{

    public async Task<Result<DeleteArticleResponse>> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
    {
        Article? article = await articleRepository.GetByIdAsync(request.ArticleId);
        if (article is null)
        {
            return Result.Failure<DeleteArticleResponse>(ArticleErrors.NotFound(request.ArticleId));
        }
        if (request.IsSoftDelete)
        {
            article.SoftDelete();
        }
        else
        {
            articleRepository.Delete(article);
            await DeleteArticleViewAsync(request.ArticleId);
        }
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new DeleteArticleResponse(article.Id);
    }
    private async Task DeleteArticleViewAsync(Guid articleViewId)
    {
        ArticleView? articleView = await articleViewRepository.GetByIdAsync(articleViewId);
        if (articleView is null)
        {
            throw new LearnTopException(nameof(DeleteArticleViewAsync), ArticleErrors.NotFound(articleViewId));
        }
        articleViewRepository.Delete(articleView);
        await articleViewRepository.SaveChangesAsync();
    }
}
