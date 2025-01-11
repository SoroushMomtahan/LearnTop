using LearnTop.Modules.Requests.Application.Tickets.Features.Queries.GetTicketsByPriority;
using LearnTop.Modules.Requests.Domain.Tickets.Enums;
using LearnTop.Shared.Application.Pagination;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace LearnTop.Modules.Requests.Presentation.Tickets.GetTicketsByPriority;

internal sealed class GetTicketsByPriorityEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/Tickets/ByPriority/{priority}", async (
                [AsParameters] PaginationRequest request,
                ISender sender) =>
            {
                Result<GetTicketsByPriorityResponse> result = await sender
                    .Send(new GetTicketsByPriorityQuery(request, TicketPriority.High));
                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .WithTags(Tags.Tickets);
    }
}
