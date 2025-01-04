using LearnTop.Modules.Blogs.Application.Abstractions.Data;
using LearnTop.Modules.Blogs.Domain.Articles.Errors;
using LearnTop.Modules.Blogs.Domain.Articles.Models;
using LearnTop.Modules.Blogs.Domain.Articles.Repositories;
using LearnTop.Modules.Users.PublicApi;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Commands.CreateArticle;

internal sealed class CreateArticleCommandHandler
    (IArticleRepository articleRepository,
    IUnitOfWork unitOfWork,
    IUsersApi usersApi) 
    : ICommandHandler<CreateArticleCommand, CreateArticleResponse>
{

    public async Task<Result<CreateArticleResponse>> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
    {
        bool isAuthorExist = await usersApi.IsExistAsync(request.AuthorId);
        if (!isAuthorExist)
        {
            return Result.Failure<CreateArticleResponse>(ArticleErrors.AuthorNotFound(request.AuthorId));
        }
        // TODO: Find Category With CategoryId
        
        Result<Article> result = Article.Create(
            request.AuthorId,
            request.CategoryId,
            request.Title,
            request.Content
            );
        if (result.IsFailure)
        {
            return Result.Failure<CreateArticleResponse>(result.Error);
        }
        
        await articleRepository.CreateAsync(result.Value);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new CreateArticleResponse(result.Value.Id);
    }
}
