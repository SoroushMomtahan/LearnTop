using LearnTop.Shared.Application.Caching;
using LearnTop.Shared.Application.Pagination;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Tagging.Tags.Features.GetTags;

internal sealed class GetTagsEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        
        app.MapGet("/Tags/All", async ([AsParameters] PaginationRequest paginationRequest, ISender sender, ICacheService cacheService) =>
        {
            GetTagsResponse? getTagsResponse = await cacheService
                .GetAsync<GetTagsResponse>(GetTagsCacheKey);
        
            if (getTagsResponse is not null)
            {
                return Results.Ok(getTagsResponse);
            }
            
            Result<GetTagsResponse> result = await sender.Send(new GetTagsQuery(paginationRequest));
            return result.Match(Results.Ok, ApiResults.Problem); 
        })
        .WithTags(EndpointTags.Tag);
        
    }
    private const string GetTagsCacheKey = "Tags:All";
}
