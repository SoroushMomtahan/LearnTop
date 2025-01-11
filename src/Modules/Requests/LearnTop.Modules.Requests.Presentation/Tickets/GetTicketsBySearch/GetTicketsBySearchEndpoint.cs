﻿using LearnTop.Modules.Requests.Application.Tickets.Features.Queries.GetTicketsBySearch;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace LearnTop.Modules.Requests.Presentation.Tickets.GetTicketsBySearch;

internal sealed class GetTicketsBySearchEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/Tickets/BySearch", async (
                [AsParameters] GetTicketsBySearchQuery query, 
                ISender sender) =>
            {
                Result<GetTicketsBySearchResponse> result = await sender.Send(query);
                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .WithTags(Tags.Tickets);
    }
}
