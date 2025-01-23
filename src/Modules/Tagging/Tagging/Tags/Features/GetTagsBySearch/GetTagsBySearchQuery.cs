using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Application.Pagination;

namespace Tagging.Tags.Features.GetTagsBySearch;

public record GetTagsBySearchQuery(PaginationRequest PaginationRequest, string SearchQuery) : IQuery<GetTagsBySearchResponse>;
