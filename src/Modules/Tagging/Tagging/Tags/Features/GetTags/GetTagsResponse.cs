using LearnTop.Shared.Application.Pagination;
using Tagging.Tags.Models;
using Tagging.Tags.Views;

namespace Tagging.Tags.Features.GetTags;

public record GetTagsResponse(PaginatedResult<TagView> PaginatedTagViewResults);
