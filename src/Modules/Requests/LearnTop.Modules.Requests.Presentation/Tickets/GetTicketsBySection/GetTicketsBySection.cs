using LearnTop.Modules.Requests.Application.Tickets.Features.Queries.GetTicketsByPriority;
using LearnTop.Modules.Requests.Application.Tickets.Features.Queries.GetTicketsBySection;
using LearnTop.Modules.Requests.Domain.Tickets.Enums;
using LearnTop.Shared.Application.Pagination;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace LearnTop.Modules.Requests.Presentation.Tickets.GetTicketsBySection;

internal sealed class GetTicketsBySection : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/Tickets/BySection", async (
                string section,
                [AsParameters] PaginationRequest request, 
                ISender sender) =>
            {
                Result<GetTicketsBySectionResponse> result = await sender
                    .Send(new GetTicketsBySectionQuery(request, Enum.Parse<TicketSection>(section)));
                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .WithTags(Tags.Tickets);
    }
}
