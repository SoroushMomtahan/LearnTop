using LearnTop.Modules.Blogs.Application.Abstractions.Data;
using LearnTop.Modules.Blogs.Domain.Articles.Errors;
using LearnTop.Modules.Blogs.Domain.Articles.Models;
using LearnTop.Modules.Blogs.Domain.Articles.Repositories;
using LearnTop.Modules.Identity.PublicApi;
using LearnTop.Modules.Users.PublicApi;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Commands.CreateArticle;

internal sealed class CreateArticleCommandHandler
    (IArticleRepository articleRepository,
    IUnitOfWork unitOfWork,
    IUserApi usersApi) 
    : ICommandHandler<CreateArticleCommand, CreateArticleResponse>
{

    public async Task<Result<CreateArticleResponse>> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
    {
        GetUserResponse user = await usersApi.GetAsync(request.AuthorId);
        if (user is null)
        {
            return Result.Failure<CreateArticleResponse>(ArticleErrors.AuthorNotFound(request.AuthorId));
        }
        // TODO: Find Category With CategoryId
        
        Result<Article> result = Article.Create(
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
        return new CreateArticleResponse(result.Value.Id);
    }
}
