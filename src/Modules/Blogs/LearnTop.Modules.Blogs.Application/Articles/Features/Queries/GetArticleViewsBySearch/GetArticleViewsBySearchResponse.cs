using LearnTop.Modules.Blogs.Domain.Articles.Views;
using LearnTop.Shared.Application.Pagination;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Queries.GetArticleViewsBySearch;

public record GetArticleViewsBySearchResponse(PaginatedResult<ArticleView> PaginatedArticleViews);
