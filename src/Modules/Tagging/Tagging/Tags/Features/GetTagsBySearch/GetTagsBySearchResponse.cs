using LearnTop.Shared.Application.Pagination;
using Tagging.Tags.Views;

namespace Tagging.Tags.Features.GetTagsBySearch;

public record GetTagsBySearchResponse(PaginatedResult<TagView> PaginatedTagViews);
