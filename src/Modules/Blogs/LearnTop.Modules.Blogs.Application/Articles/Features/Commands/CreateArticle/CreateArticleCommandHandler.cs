using LearnTop.Modules.Blogs.Domain.Articles.Models;
using LearnTop.Modules.Blogs.Domain.Articles.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Commands.CreateArticle;

internal sealed class CreateArticleCommandHandler(IArticleRepository articleRepository) 
    : ICommandHandler<CreateArticleCommand, CreateArticleResponse>
{

    public async Task<Result<CreateArticleResponse>> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
    {
        // TODO: Find Author With AuthorId
        // TODO: Find Category With CategoryId
        
        Result<Article> blog = Article.Create(
            request.AuthorId,
            request.CategoryId,
            request.Title,
            request.Content
            );
        if (blog.IsFailure)
        {
            return Result.Failure<CreateArticleResponse>(blog.Error);
        }
        await articleRepository.CreateAsync(blog.Value);
        return new CreateArticleResponse(blog.Value.Id);
    }
}
