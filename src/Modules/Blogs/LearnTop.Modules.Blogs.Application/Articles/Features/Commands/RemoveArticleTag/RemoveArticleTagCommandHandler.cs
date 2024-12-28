using LearnTop.Modules.Blogs.Application.Abstractions.Data;
using LearnTop.Modules.Blogs.Domain.Articles.Errors;
using LearnTop.Modules.Blogs.Domain.Articles.Models;
using LearnTop.Modules.Blogs.Domain.Articles.Repositories;
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
        Article? blog = await articleRepository.GetByIdAsync(request.ArticleId);
        
        if (blog is null)
        {
            return Result.Failure<RemoveArticleTagResponse>(ArticleErrors.NotFound(request.ArticleId));
        }
        
        Result result = blog.RemoveTag(new(request.TagId, request.ArticleId));
        if (result.IsFailure)
        {
            return Result.Failure<RemoveArticleTagResponse>(result.Error);
        }
        articleRepository.DeleteTag(new(request.TagId, request.ArticleId));
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new RemoveArticleTagResponse(request.ArticleId);
    }
}
