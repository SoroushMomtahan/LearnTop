using LearnTop.Modules.Blogs.Application.Articles.Features.Queries.GetArticleViews;
using LearnTop.Shared.Application.Pagination;

namespace LearnTop.Modules.Blogs.Presentation.Articles.GetArticleViews;

internal sealed class GetArticleViewsEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/Articles", async ([AsParameters] PaginationRequest paginationRequest, ISender sender) =>
        {
            Result<GetArticleViewsResponse> result = await sender.Send(
                new GetArticleViewsQuery(paginationRequest)
                );
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Articles);
    }
}
