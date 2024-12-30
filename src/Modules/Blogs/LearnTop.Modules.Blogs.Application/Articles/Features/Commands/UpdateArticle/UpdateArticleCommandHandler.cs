using LearnTop.Modules.Blogs.Application.Abstractions.Data;
using LearnTop.Modules.Blogs.Domain.Articles.Errors;
using LearnTop.Modules.Blogs.Domain.Articles.Models;
using LearnTop.Modules.Blogs.Domain.Articles.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Commands.UpdateArticle;

internal sealed class UpdateArticleCommandHandler
    (IArticleRepository articleRepository,
    IUnitOfWork unitOfWork) 
    :ICommandHandler<UpdateArticleCommand, UpdateArticleResponse>
{

    public async Task<Result<UpdateArticleResponse>> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
    {
        Article? article = await articleRepository.GetByIdAsync(request.ArticleId);
        if (article is null)
        {
            return Result.Failure<UpdateArticleResponse>(ArticleErrors.NotFound(request.ArticleId));
        }
        article.Update(
            request.Title,
            request.Content
            );
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new UpdateArticleResponse(article.Id);
    }
}
