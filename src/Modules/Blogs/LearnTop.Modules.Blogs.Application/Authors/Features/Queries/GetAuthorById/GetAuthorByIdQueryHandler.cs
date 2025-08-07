using LearnTop.Modules.Blogs.Application.Authors.Services;
using LearnTop.Modules.Blogs.Application.Authors.Views;
using LearnTop.Modules.Blogs.Domain.Aggregates.Authors.Errors;
using LearnTop.Shared.Application.Cqrs;
using LearnTop.Shared.Domain;

namespace LearnTop.Modules.Blogs.Application.Authors.Features.Queries.GetAuthorById;

internal sealed class GetAuthorByIdQueryHandler(IAuthorQueryService authorQueryService) 
    : IQueryHandler<GetAuthorByIdQuery, GetAuthorByIdQuery.Result>
{

    public async Task<Result<GetAuthorByIdQuery.Result>> Handle(
        GetAuthorByIdQuery request, 
        CancellationToken cancellationToken)
    {
        AuthorView? authorView = await authorQueryService.GetAsync(request.AuthorId);
        if (authorView is null)
        {
            return Result.Failure<GetAuthorByIdQuery.Result>(AuthorErrors.NotFound(request.AuthorId));
        }
        
        return new GetAuthorByIdQuery.Result(authorView);
    }
}
