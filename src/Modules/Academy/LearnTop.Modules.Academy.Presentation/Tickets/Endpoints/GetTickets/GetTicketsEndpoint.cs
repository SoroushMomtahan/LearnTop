using LearnTop.Modules.Academy.Application.Tickets.Queries.GetTickets;
using LearnTop.Shared.Application.Caching;
using LearnTop.Shared.Application.Pagination;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace LearnTop.Modules.Academy.Presentation.Tickets.Endpoints.GetTickets;

public class GetTicketsEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("tickets", static async
            ([AsParameters] PaginationRequest request,
                [FromServices] ISender sender,
                ICacheService cacheService) =>
            {
                GetTicketsQueryResult getTicketsQueryResult = await
                    cacheService.GetAsync<GetTicketsQueryResult>("tickets");
                if (getTicketsQueryResult is not null)
                {
                    return Results.Ok(getTicketsQueryResult);
                }

                var query = new GetTicketsQuery(request);

                Result<GetTicketsQueryResult> result = await sender.Send(query);
                if (result.IsSuccess)
                {
                    await cacheService.SetAsync("tickets", result.Value);
                }

                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .WithTags(Tags.Tickets);
    }
}
