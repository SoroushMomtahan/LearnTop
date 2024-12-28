using LearnTop.Modules.Blogs.Application.Articles.Features.Queries.GetArticleViewsByTagIds;
using LearnTop.Shared.Application.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace LearnTop.Modules.Blogs.Presentation.Articles.GetArticleViewsByTagIds;

internal sealed class GetArticleViewsByTagIdsEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/Articles/ByTagId", async (
            [AsParameters] PaginationRequest paginationRequest,
            string tagIds,
            ISender sender) =>
        {
            var tagIdList = tagIds.Split(',').ToList();
            Result<GetArticleViewsByTagIdsResponse> result = await sender.Send(
                new GetArticleViewsByTagIdsQuery(paginationRequest, tagIdList)
                );
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Articles);
    }
}
