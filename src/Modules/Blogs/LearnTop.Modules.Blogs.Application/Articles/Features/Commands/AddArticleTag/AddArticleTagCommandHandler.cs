using LearnTop.Modules.Blogs.Domain.Articles.Errors;
using LearnTop.Modules.Blogs.Domain.Articles.Models;
using LearnTop.Modules.Blogs.Domain.Articles.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Commands.AddArticleTag;

internal sealed class AddArticleTagCommandHandler(IArticleRepository articleRepository)
    : ICommandHandler<AddArticleTagCommand, AddArticleTagResponse>
{

    public async Task<Result<AddArticleTagResponse>> Handle(AddArticleTagCommand request, CancellationToken cancellationToken)
    {
        
        Article? blog = await articleRepository.GetByIdAsync(request.BlogId);
        if (blog is null)
        {
            return Result.Failure<AddArticleTagResponse>(ArticleErrors.NotFound(request.BlogId));
        }
        
        // TODO: Find Tags With TagIds
        
        blog.AddTag(new(request.TagId, request.BlogId));

        await articleRepository.UpdateTagsAsync(blog);
        return new AddArticleTagResponse(blog.Id);
    }
}
