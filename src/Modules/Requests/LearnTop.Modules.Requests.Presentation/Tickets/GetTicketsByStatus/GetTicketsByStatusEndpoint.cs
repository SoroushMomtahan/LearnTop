using LearnTop.Modules.Requests.Application.Tickets.Features.Queries.GetTicketsByStatus;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace LearnTop.Modules.Requests.Presentation.Tickets.GetTicketsByStatus;

internal sealed class GetTicketsByStatusEndpoint : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/Tickets/ByStatus", async (
                [AsParameters] GetTicketsByStatusQuery query, 
                ISender sender) =>
            {
                Result<GetTicketsByStatusResponse> result = await sender.Send(query);
                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .WithTags(Tags.Tickets);
    }
}
