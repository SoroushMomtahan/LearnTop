using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Application.Pagination;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Queries.GetArticleViewsBySearch;

public record GetArticleViewsBySearchQuery(PaginationRequest Request, string SearchString)
    : IQuery<GetArticleViewsBySearchResponse>;
