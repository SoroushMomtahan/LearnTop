using LearnTop.Modules.Requests.Application.Tickets.Features.Commands.ChangeTicketStatus;
using LearnTop.Shared.Domain;
using LearnTop.Shared.Presentation.ApiResults;
using LearnTop.Shared.Presentation.Endpoints;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace LearnTop.Modules.Requests.Presentation.Tickets.ChangeTicketStatus;

internal sealed class ChangeTicketStatusEndpoint : IEndpoint
{

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPatch("/Tickets/Status", async (
            ChangeTicketStatusCommand command,
            ISender sender) =>
        {
            Result<ChangeTicketStatusResponse> result = await sender.Send(command);
            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .WithTags(Tags.Tickets);
    }
}
