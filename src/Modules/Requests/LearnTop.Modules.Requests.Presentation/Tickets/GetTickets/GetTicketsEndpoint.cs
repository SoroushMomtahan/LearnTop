﻿using LearnTop.Modules.Requests.Application.Tickets.Features.Queries.GetTickets;
using LearnTop.Shared.Application.Pagination;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace LearnTop.Modules.Requests.Presentation.Tickets.GetTickets;

internal sealed class GetTicketsEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/Tickets", static async (
                [AsParameters] PaginationRequest request,
                [FromServices] ISender sender) =>
            {
                var query = new GetTicketsQuery(request);

                Result<GetTicketsQueryResponse> result = await sender.Send(query);

                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .WithTags(Tags.Tickets);
    }
}
