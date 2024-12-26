using LearnTop.Modules.Blogs.Domain.Articles.Views;
using LearnTop.Shared.Application.Pagination;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Queries.GetArticleViews;

public record GetArticleViewsResponse(PaginatedResult<ArticleView> PaginatedArticleViews);
