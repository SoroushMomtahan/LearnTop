using LearnTop.Modules.Blogs.Domain.Articles.Errors;
using LearnTop.Modules.Blogs.Domain.Articles.Models;
using LearnTop.Modules.Blogs.Domain.Articles.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Commands.RemoveArticleTag;

internal sealed class RemoveArticleTagCommandHandler(IArticleRepository articleRepository)
    : ICommandHandler<RemoveArticleTagCommand, RemoveArticleTagResponse>
{

    public async Task<Result<RemoveArticleTagResponse>> Handle(RemoveArticleTagCommand request, CancellationToken cancellationToken)
    {
        Article? blog = await articleRepository.GetByIdAsync(request.BlogId);
        
        if (blog is null)
        {
            return Result.Failure<RemoveArticleTagResponse>(ArticleErrors.NotFound(request.BlogId));
        }
        
        Result result = blog.RemoveTag(new(request.TagId, request.BlogId));
        if (result.IsFailure)
        {
            return Result.Failure<RemoveArticleTagResponse>(result.Error);
        }
        await articleRepository.DeleteTagAsync(new(request.TagId, request.BlogId));
        
        return new RemoveArticleTagResponse(request.BlogId);
    }
}
