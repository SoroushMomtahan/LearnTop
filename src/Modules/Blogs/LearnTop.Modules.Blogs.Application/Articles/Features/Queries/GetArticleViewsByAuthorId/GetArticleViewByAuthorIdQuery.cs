using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Application.Pagination;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Queries.GetArticleViewsByAuthorId;

public record GetArticleViewByAuthorIdQuery(PaginationRequest PaginationRequest, Guid AuthorId)
    : IQuery<GetArticleViewByAuthorIdResponse>;
