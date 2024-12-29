using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Application.Pagination;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Queries.GetArticleViewsByTagIds;

public record GetArticleViewsByTagIdsQuery(PaginationRequest PaginationRequest, List<Guid> TagIds)
    : IQuery<GetArticleViewsByTagIdsResponse>;
