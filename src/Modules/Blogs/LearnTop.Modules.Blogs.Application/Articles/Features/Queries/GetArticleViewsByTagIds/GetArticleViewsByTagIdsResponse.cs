using LearnTop.Modules.Blogs.Application.Views.ArticleViews;
using LearnTop.Shared.Application.Pagination;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Queries.GetArticleViewsByTagIds;

public record GetArticleViewsByTagIdsResponse(PaginatedResult<ArticleView> PaginatedArticleViews);
