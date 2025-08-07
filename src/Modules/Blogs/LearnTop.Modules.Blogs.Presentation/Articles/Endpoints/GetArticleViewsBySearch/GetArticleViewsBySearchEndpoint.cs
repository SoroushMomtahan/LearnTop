using LearnTop.Modules.Blogs.Application.Articles.Features.Queries.GetArticleViewsBySearch;
using LearnTop.Shared.Application.Pagination;

namespace LearnTop.Modules.Blogs.Presentation.Articles.Endpoints.GetArticleViewsBySearch;

internal sealed class GetArticleViewsBySearchEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/Articles/BySearch", async (
            string? searchString,
            [AsParameters] PaginationRequest paginationRequest, 
            ISender sender) =>
        {
            Result<GetArticleViewsBySearchResponse> result = await sender.Send(new GetArticleViewsBySearchQuery(paginationRequest, searchString));
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Articles);
    }
}
