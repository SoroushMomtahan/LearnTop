using LearnTop.Modules.Blogs.Application.Articles.Features.Queries.GetArticleViewsByCategoryId;
using LearnTop.Shared.Application.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace LearnTop.Modules.Blogs.Presentation.Articles.GetArticleViewsByCategoryId;

internal sealed class GetArticleViewByCategoryIdEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/Articles/ByCategoryId{categoryId:guid}", async (
                [FromRoute] Guid categoryId,
                [AsParameters] PaginationRequest paginationRequest,
                ISender sender) =>
            {
                Result<GetArticleViewsByCategoryIdResponse> result = await sender.Send(
                    new GetArticleViewsByCategoryIdQuery(paginationRequest, categoryId)
                    );
                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .WithTags(Tags.Articles);
    }
}
