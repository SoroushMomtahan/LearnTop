using LearnTop.Modules.Blogs.Application.Abstractions.Data;
using LearnTop.Modules.Blogs.Domain.Aggregates.Articles.Errors;
using LearnTop.Modules.Blogs.Domain.Aggregates.Articles.Models;
using LearnTop.Modules.Blogs.Domain.Aggregates.Articles.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Commands.DeleteArticle;

public class DeleteArticleCommandHandler
    (IArticleRepository articleRepository,
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
        }
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new DeleteArticleResponse(article.Id);
    }
}
