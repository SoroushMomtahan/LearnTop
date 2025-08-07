using LearnTop.Modules.Blogs.Application.Articles.Features.Queries.GetArticleViewsByAuthorId;
using LearnTop.Shared.Application.Pagination;

namespace LearnTop.Modules.Blogs.Presentation.Articles.Endpoints.GetArticleViewsByAuthorId;

internal sealed class GetArticleViewsByAuthorId : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/Articles/ByAuthorId/{authorId:guid}", async (
                Guid authorId,
                [AsParameters] PaginationRequest paginationRequest,
                ISender sender) =>
            {
                Result<GetArticleViewByAuthorIdResponse> result =
                    await sender.Send(new GetArticleViewByAuthorIdQuery(paginationRequest, authorId));
                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .WithTags(Tags.Articles);
    }
}
