using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Application.Pagination;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Queries.GetArticleViewsByCategoryId;

public record GetArticleViewsByCategoryIdQuery(PaginationRequest PaginationRequest, Guid CategoryId)
    : IQuery<GetArticleViewsByCategoryIdResponse>;
