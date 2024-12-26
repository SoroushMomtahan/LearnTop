using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Application.Pagination;

namespace LearnTop.Modules.Blogs.Application.Articles.Features.Queries.GetArticleViewById;

public record GetArticleViewByIdQuery(Guid ArticleId) 
    : IQuery<GetArticleViewByIdResponse>;
