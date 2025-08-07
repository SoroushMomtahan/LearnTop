using LearnTop.Modules.Blogs.Application.Articles.Features.Queries.GetArticleViewsByTagIds;
using LearnTop.Shared.Application.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace LearnTop.Modules.Blogs.Presentation.Articles.Endpoints.GetArticleViewsByTagIds;

internal sealed class GetArticleViewsByTagIdsEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/Articles/ByTagId", async (
                [AsParameters] PaginationRequest paginationRequest,
                [FromQuery] string[] tagIds,
                ISender sender) =>
            {
                var guids = tagIds.Select(Guid.Parse).ToList();
                Result<GetArticleViewsByTagIdsResponse> result = await sender.Send(
                    new GetArticleViewsByTagIdsQuery(paginationRequest, guids)
                    );
                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .WithTags(Tags.Articles);
    }
}
