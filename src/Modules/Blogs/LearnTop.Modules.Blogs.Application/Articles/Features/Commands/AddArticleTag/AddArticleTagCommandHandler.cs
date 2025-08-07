using LearnTop.Modules.Blogs.Application.Abstractions.Data;
using LearnTop.Modules.Blogs.Domain.Aggregates.Articles.Errors;
using LearnTop.Modules.Blogs.Domain.Aggregates.Articles.Models;
using LearnTop.Modules.Blogs.Domain.Aggregates.Articles.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Commands.AddArticleTag;

internal sealed class AddArticleTagCommandHandler
    (IArticleRepository articleRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<AddArticleTagCommand, AddArticleTagResponse>
{

    public async Task<Result<AddArticleTagResponse>> Handle(AddArticleTagCommand request, CancellationToken cancellationToken)
    {
        
        Article? article = await articleRepository.GetByIdAsync(request.ArticleId);
        if (article is null)
        {
            return Result.Failure<AddArticleTagResponse>(ArticleErrors.NotFound(request.ArticleId));
        }
        
        // TODO: Find Tag With TagId
        
        request.TagIds.ForEach(article.AddTag);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new AddArticleTagResponse(article.Id);
    }
}
