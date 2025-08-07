using LearnTop.Modules.Blogs.Application.Authors.Views;
using LearnTop.Shared.Application.Cqrs;

namespace LearnTop.Modules.Blogs.Application.Authors.Features.Queries.GetAuthorById;

public record GetAuthorByIdQuery(Guid AuthorId) : IQuery<GetAuthorByIdQuery.Result>
{
    public record Result(AuthorView AuthorView);
};
