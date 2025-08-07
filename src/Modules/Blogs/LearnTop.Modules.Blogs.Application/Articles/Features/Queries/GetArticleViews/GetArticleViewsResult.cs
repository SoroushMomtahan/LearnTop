using LearnTop.Modules.Blogs.Application.Articles.Dtos;
using LearnTop.Modules.Blogs.Application.Articles.Views;
using LearnTop.Shared.Application.Pagination;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Queries.GetArticleViews;

public record GetArticleViewsResult(PaginatedResult<ArticleView> PaginatedArticleViews);
