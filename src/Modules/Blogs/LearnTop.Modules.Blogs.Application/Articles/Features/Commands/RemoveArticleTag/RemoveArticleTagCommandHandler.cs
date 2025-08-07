using LearnTop.Modules.Blogs.Application.Abstractions.Data;
using LearnTop.Modules.Blogs.Domain.Aggregates.Articles.Errors;
using LearnTop.Modules.Blogs.Domain.Aggregates.Articles.Models;
using LearnTop.Modules.Blogs.Domain.Aggregates.Articles.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Commands.RemoveArticleTag;

internal sealed class RemoveArticleTagCommandHandler
    (IArticleRepository articleRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<RemoveArticleTagCommand, RemoveArticleTagResponse>
{

    public async Task<Result<RemoveArticleTagResponse>> Handle(RemoveArticleTagCommand request, CancellationToken cancellationToken)
    {
        Article? article = await articleRepository.GetByIdAsync(request.ArticleId);
        
        if (article is null)
        {
            return Result.Failure<RemoveArticleTagResponse>(ArticleErrors.NotFound(request.ArticleId));
        }
        
        Result result = article.RemoveTag(request.TagId);

        if (result.IsFailure)
        {
            return Result.Failure<RemoveArticleTagResponse>(result.Error);
        }
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new RemoveArticleTagResponse(request.ArticleId);
    }
}
