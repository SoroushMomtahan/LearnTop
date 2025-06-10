using LearnTop.Modules.Blogs.Application.Articles.Dtos;
using LearnTop.Modules.Blogs.Application.Views.ArticleViews;
using LearnTop.Shared.Application.Pagination;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Queries.GetArticleViews;

public record GetArticleViewsResponse(PaginatedResult<ArticleView> PaginatedArticles);
