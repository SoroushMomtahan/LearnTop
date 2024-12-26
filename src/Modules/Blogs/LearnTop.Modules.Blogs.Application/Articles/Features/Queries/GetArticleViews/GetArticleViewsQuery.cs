using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Application.Pagination;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Queries.GetArticleViews;

public record GetArticleViewsQuery(PaginationRequest PaginationRequest)
    : IQuery<GetArticleViewsResponse>;
