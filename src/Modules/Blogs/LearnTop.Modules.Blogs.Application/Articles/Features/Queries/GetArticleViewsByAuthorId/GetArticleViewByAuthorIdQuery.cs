using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Application.Pagination;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Queries.GetArticleViewsByAuthorId;

public record GetArticleViewByAuthorIdQuery(PaginationRequest Request, Guid AuthorId)
    : IQuery<GetArticleViewByAuthorIdResponse>;
