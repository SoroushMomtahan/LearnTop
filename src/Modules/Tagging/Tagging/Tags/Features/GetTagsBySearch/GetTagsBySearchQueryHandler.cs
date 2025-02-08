using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Application.Pagination;
using LearnTop.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Tagging.Data.ReadDb;
using Tagging.Data.WriteDb;
using Tagging.Tags.Views;

namespace Tagging.Tags.Features.GetTagsBySearch;

internal sealed class GetTagsBySearchQueryHandler(TaggingViewDbContext taggingViewDbContext) : IQueryHandler<GetTagsBySearchQuery, GetTagsBySearchResponse>
{

    public async Task<Result<GetTagsBySearchResponse>> Handle(GetTagsBySearchQuery request, CancellationToken cancellationToken)
    {
        int pageIndex = request.PaginationRequest.PageIndex;
        int pageSize = request.PaginationRequest.PageSize;
        long totalCount = await taggingViewDbContext.TagViews.LongCountAsync(cancellationToken);
        
        List<TagView> tagViews = await taggingViewDbContext.TagViews
            .AsNoTracking()
            .Where(x=>x.Title.Contains(request.SearchQuery))
            .Skip(request.PaginationRequest.PageIndex)
            .Take(request.PaginationRequest.PageSize)
            .ToListAsync(cancellationToken);
        
        PaginatedResult<TagView> paginatedTagViews =
            new(pageIndex, pageSize, totalCount, tagViews);
        
        return new GetTagsBySearchResponse(paginatedTagViews);
    }
}
