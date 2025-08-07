using LearnTop.Modules.Blogs.Application.Abstractions.Data;
using LearnTop.Modules.Blogs.Domain.Aggregates.Articles.Errors;
using LearnTop.Modules.Blogs.Domain.Aggregates.Articles.Models;
using LearnTop.Modules.Blogs.Domain.Aggregates.Articles.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Commands.ChangeArticleStatus;

public class ChangeArticleStatusCommandHandler
    (IArticleRepository articleRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<ChangeArticleStatusCommand, ChangeArticleStatusResponse>
{

    public async Task<Result<ChangeArticleStatusResponse>> Handle(ChangeArticleStatusCommand request, CancellationToken cancellationToken)
    {
        Article? article = await articleRepository.GetByIdAsync(request.ArticleId);
        if (article is null)
        {
            return Result.Failure<ChangeArticleStatusResponse>(ArticleErrors.NotFound(request.ArticleId));
        }
        Result result = article.ChangeStatus(request.Status);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return result.IsFailure 
            ? Result.Failure<ChangeArticleStatusResponse>(result.Error)
            : new ChangeArticleStatusResponse(article.Id);
    }
}
