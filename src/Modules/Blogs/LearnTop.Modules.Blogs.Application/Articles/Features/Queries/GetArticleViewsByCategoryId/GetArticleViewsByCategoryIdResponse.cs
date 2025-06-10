using LearnTop.Modules.Blogs.Application.Views.ArticleViews;
using LearnTop.Shared.Application.Pagination;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Queries.GetArticleViewsByCategoryId;

public record GetArticleViewsByCategoryIdResponse(PaginatedResult<ArticleView> PaginatedArticleViews);
