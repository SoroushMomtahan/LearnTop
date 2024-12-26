using LearnTop.Modules.Blogs.Domain.Blogs.Errors;
using LearnTop.Modules.Blogs.Domain.Blogs.Models;
using LearnTop.Modules.Blogs.Domain.Blogs.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Application.Blogs.Features.Commands.RemoveBlogTag;

internal sealed class RemoveBlogTagCommandHandler(IBlogRepository blogRepository)
    : ICommandHandler<RemoveBlogTagCommand, RemoveBlogTagResponse>
{

    public async Task<Result<RemoveBlogTagResponse>> Handle(RemoveBlogTagCommand request, CancellationToken cancellationToken)
    {
        Blog? blog = await blogRepository.GetByIdAsync(request.BlogId);
        
        if (blog is null)
        {
            return Result.Failure<RemoveBlogTagResponse>(BlogErrors.NotFound(request.BlogId));
        }
        
        Result result = blog.RemoveTag(new(request.TagId, request.BlogId));
        if (result.IsFailure)
        {
            return Result.Failure<RemoveBlogTagResponse>(result.Error);
        }
        await blogRepository.DeleteTagAsync(new(request.TagId, request.BlogId));
        
        return new RemoveBlogTagResponse(request.BlogId);
    }
}
