using LearnTop.Modules.Blogs.Application.Articles.Dtos;
using LearnTop.Modules.Blogs.Application.Articles.Features.Queries.GetArticleViews;
using LearnTop.Modules.Blogs.Domain.Aggregates.Articles.enums;
using LearnTop.Modules.Blogs.Presentation.Articles.Mappers;
using LearnTop.Shared.Application.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace LearnTop.Modules.Blogs.Presentation.Articles.Endpoints.GetArticleViews;

public record GetArticleViewsRequest(string? Search, Status? Status, bool? IsActive = true, int? PageIndex = 0, int? PageSize = 10)
{
    public record Response(PaginatedResult<ArticleDto> PaginatedResponse);
}

internal sealed class GetArticleViewsEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/Articles", async ([AsParameters] GetArticleViewsRequest request, ISender sender) =>
            {
                GetArticleViewsQuery query = request.ToQuery();
                
                Result<GetArticleViewsResult> result = await sender.Send(query);
                
                Result<GetArticleViewsRequest.Response> response = result.ToResponse();
                
                return response.Match(Results.Ok, ApiResults.Problem);
            })
            .WithTags(Tags.Articles)
            .Produces<GetArticleViewsResult>(200, "application/json")
            .Produces(406)
            .AddEndpointFilter(async (context, @delegate) =>
            {
                string? contentType = context.HttpContext.Request.Headers.Accept;
                if (contentType != null && !contentType.Contains("application/json"))
                {
                    return Results.StatusCode(StatusCodes.Status406NotAcceptable);
                }

                return await @delegate(context);
            });
    }
}
