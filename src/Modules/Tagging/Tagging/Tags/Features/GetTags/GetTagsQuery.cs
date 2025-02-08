using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Application.Pagination;

namespace Tagging.Tags.Features.GetTags;

public record GetTagsQuery(
    PaginationRequest PaginationRequest) : IQuery<GetTagsResponse>;
