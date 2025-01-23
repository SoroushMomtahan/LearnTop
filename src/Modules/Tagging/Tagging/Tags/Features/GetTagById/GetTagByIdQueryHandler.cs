using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Tagging.Data.ReadDb;
using Tagging.Tags.Errors;
using Tagging.Tags.Views;

namespace Tagging.Tags.Features.GetTagById;

internal sealed class GetTagByIdQueryHandler(TaggingViewDbContext taggingViewDbContext)
    : IQueryHandler<GetTagByIdQuery, GetTagByIdResponse>
{

    public async Task<Result<GetTagByIdResponse>> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
    {
        TagView? tagView = await taggingViewDbContext.TagViews.FirstOrDefaultAsync(x => x.Id == request.TagId, cancellationToken);
        return tagView is null ? 
            Result.Failure<GetTagByIdResponse>(TagErrors.TagNotFound) 
            : new GetTagByIdResponse(tagView);
    }
}
