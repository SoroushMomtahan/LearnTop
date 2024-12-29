using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Application.Pagination;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Queries.GetArticleViewsBySearch;

public record GetArticleViewsBySearchQuery(PaginationRequest PaginationRequest, string SearchString)
    : IQuery<GetArticleViewsBySearchResponse>;
