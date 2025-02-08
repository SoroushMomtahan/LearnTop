using LearnTop.Shared.Application.Caching;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Application.Pagination;
using LearnTop.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Tagging.Data.ReadDb;
using Tagging.Tags.Views;

namespace Tagging.Tags.Features.GetTags;

internal sealed class GetTagsQueryHandler(
    TaggingViewDbContext taggingViewDbContext) : IQueryHandler<GetTagsQuery, GetTagsResponse>
{

    public async Task<Result<GetTagsResponse>> Handle(GetTagsQuery request, CancellationToken cancellationToken)
    {
        int pageIndex = request.PaginationRequest.PageIndex;
        int pageSize = request.PaginationRequest.PageSize;
        long totalCount = await taggingViewDbContext.TagViews.LongCountAsync(cancellationToken);
        
        List<TagView> tagViews =  await taggingViewDbContext.TagViews
            .Skip(pageIndex)
            .Take(pageSize)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        PaginatedResult<TagView> paginatedResult = new(
            pageIndex,
            pageSize,
            totalCount,
            tagViews);
        
        return new GetTagsResponse(paginatedResult);
    }
}
