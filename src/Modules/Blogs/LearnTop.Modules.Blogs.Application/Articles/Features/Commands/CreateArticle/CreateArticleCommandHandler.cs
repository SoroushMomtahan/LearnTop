using LearnTop.Modules.Blogs.Application.Abstractions.Data;
using LearnTop.Modules.Blogs.Domain.Aggregates.Articles.Models;
using LearnTop.Modules.Blogs.Domain.Aggregates.Articles.Repositories;
using LearnTop.Modules.Identity.PublicApi;
using LearnTop.Modules.Users.PublicApi;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Commands.CreateArticle;

internal sealed class CreateArticleCommandHandler
    (IArticleRepository articleRepository,
    IUnitOfWork unitOfWork) 
    : ICommandHandler<CreateArticleCommand, CreateArticleResponse>
{

    public async Task<Result<CreateArticleResponse>> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
    {
#pragma warning disable S125
        // GetUserResponse user = await usersApi.GetAsync(request.AuthorId);
        // if (user is null)
        // {
        //     return Result.Failure<CreateArticleResponse>(ArticleErrors.AuthorNotFound(request.AuthorId));
        // }
#pragma warning disable S125
        // TODO: Find Category With CategoryId
        
        
        Result<Article> result = Article.CreatePublic(
            request.AuthorId,
            request.CategoryId,
            request.CoverName,
            request.Title,
            request.ShortContent,
            request.Content
            );
        if (result.IsFailure)
        {
            return Result.Failure<CreateArticleResponse>(result.Error);
        }
        
        await articleRepository.CreateAsync(result.Value);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success<CreateArticleResponse>(new(result.Value.Id));

        
        // throw new NotImplementedException();
    }
}
