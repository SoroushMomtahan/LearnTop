using LearnTop.Modules.Blogs.Domain.Blogs.Errors;
using LearnTop.Modules.Blogs.Domain.Blogs.Models;
using LearnTop.Modules.Blogs.Domain.Blogs.Repositories;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Application.Blogs.Features.Commands.ChangeBlogStatus;

public class ChangeBlogStatusCommandHandler(IBlogRepository blogRepository)
    : ICommandHandler<ChangeBlogStatusCommand, ChangeBlogStatusResponse>
{

    public async Task<Result<ChangeBlogStatusResponse>> Handle(ChangeBlogStatusCommand request, CancellationToken cancellationToken)
    {
        Blog? blog = await blogRepository.GetByIdAsync(request.BlogId);
        if (blog is null)
        {
            return Result.Failure<ChangeBlogStatusResponse>(BlogErrors.NotFound(request.BlogId));
        }
        Result result = blog.ChangeStatus(request.Status);
        return result.IsFailure 
            ? Result.Failure<ChangeBlogStatusResponse>(result.Error)
            : new ChangeBlogStatusResponse(blog.Id);
    }
}
